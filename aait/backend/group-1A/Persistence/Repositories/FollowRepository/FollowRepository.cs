
using Application.Contracts;
using Application.DTO.FollowDTo;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using SocialSync.Domain.Entities;

namespace Persistence.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        SocialMediaDbContext _socialMediaDbContext;
        public FollowRepository(SocialMediaDbContext socialMediaDbContext)
        {
            _socialMediaDbContext = socialMediaDbContext;
        }
        public async Task<Follow> AddFollow(Follow follow)
        {
            await _socialMediaDbContext.AddAsync(follow);
            await _socialMediaDbContext.SaveChangesAsync();

            return follow;
        }

        public async Task DeleteFollow(Follow follow)
        {
            _socialMediaDbContext.Remove(follow);
            await _socialMediaDbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetFollowers(int Id)
        {
             var user = await _socialMediaDbContext.Users
                .Include(x => x.Followee)
                .Include(x => x.Follower)
                .FirstOrDefaultAsync(u => u.Id == Id);
            

            if (user != null)
            {
                var followerIds = user.Followee.Select(f => f.FollowerId).ToList();
                var usersThatFollowUser = await _socialMediaDbContext.Users
                    .Where(u => followerIds.Contains(u.Id))
                    .ToListAsync();

                return usersThatFollowUser;
            }
            
            else
            {
                return new List<User>(); 
            }

        }
        public async Task<List<User>> GetFollowedUsers (int Id)
        {
            var user = await _socialMediaDbContext.Users
            .Include(x => x.Followee)
            .Include(x => x.Follower)
            .FirstOrDefaultAsync(u => u.Id == Id);

            if (user != null)
            {
                var followeeIds = user.Follower.Select(f => f.FolloweeId).ToList();
                var usersFollowedByThisUser = await _socialMediaDbContext.Users
                    .Where(u => followeeIds.Contains(u.Id))
                    .ToListAsync();

                return usersFollowedByThisUser;
            }

            else
            {
                return new List<User>();
            }
        }

        public async Task<Follow> Get(FollowDTO follow)
        {
            return await _socialMediaDbContext.Follow.Where(f => f.FollowerId == follow.FollowerId && f.FolloweeId == follow.FolloweeId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Follow>> GetAll()
        {
            return await _socialMediaDbContext.Follow.ToListAsync();
        }

    }
}