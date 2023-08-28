using Application.Contracts.Persistence;
using Application.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialSyncDbContext _context;

        public UserRepository(SocialSyncDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int userId)
        {
            if (await _context.Users.AnyAsync<User>(user => user.Id == userId))
                return true;

            return false;
        }

        public async Task<bool> FollowUser(int followerId, int followeeId)
        {
            if (followeeId == followerId)
            {
                throw new BadRequestException("you can't follow yourself");
            }
            if (await _context.Follows.FirstOrDefaultAsync<Follow>(f => f.FollowerId == followerId && f.FolloweeId == followeeId) != null)
            {
                throw new BadRequestException("already following the user");
            }

            if (await _context.Users.FirstOrDefaultAsync<User>(u => u.Id == followeeId) == null)
            {
                throw new NotFoundException("user not found", typeof(User));
            }

            var follow = new Follow()
            {
                FolloweeId = followeeId,
                FollowerId = followerId
            };

            await _context.Follows.AddAsync(follow);
            await _context.SaveChangesAsync();

            return true;



        }

        public async Task<User?> GetUserDetail(int userId)
        {
            return await _context.Users.Include(u => u.Comments).Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<List<User>> GetUsers(int userId, bool getFollower)
        {
            var user = await _context.Users
                .Include(u => u.Followers)
                .Include(u => u.Followees)
                .FirstOrDefaultAsync(u => u.Id == userId);


            

            var users = await _context.Users.ToListAsync();

            if (user == null)
            {
                throw new NotFoundException("user not found", typeof(User));
            }

            if (getFollower)
            {

                var followers = user.Followers;

                return users.Where(u => followers.Any(f => f.FollowerId == u.Id)).ToList();


            }
            else
            {


                var followees = user.Followees;

                return users.Where(u => followees.Any(f => f.FolloweeId == u.Id)).ToList();
            }


        }

        public async Task<bool> UnFollowUser(int followerId, int followeeId)
        {
            var follow = await _context.Follows.FirstOrDefaultAsync<Follow>(f => f.FollowerId == followerId && f.FolloweeId == followeeId);
            if (follow == null)
            {
                throw new BadRequestException("not following the user");
            }

            _context.Follows.Remove(follow);

            await _context.SaveChangesAsync();

            return true;


        }

        public async Task UpdateUser(User user)
        {
            var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == user.Id);

            if (userToUpdate == null)
            {
                throw new NotFoundException("user not found", typeof(User));
            }

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Bio = user.Bio;

            await _context.SaveChangesAsync();

        }
    }
}
