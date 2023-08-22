using Application.Contracts.Persistance;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly SocialSyncDbContext _dbContext;

        public FollowRepository(SocialSyncDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Follow>> GetFollowing(int id)
        {
            return await _dbContext.Follows
                .Where(f => f.FollowerId == id)
                .ToListAsync();
        }

        public async Task<List<Follow>> GetFollower(int id)
        {
            return await _dbContext.Follows
                .Where(f => f.FollowedId == id)
                .ToListAsync();
        }

        public async Task Follow(Follow follow)
        {
            await _dbContext.Follows.AddAsync(follow);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Unfollow(Follow follow)
        {
            _dbContext.Follows.Remove(follow);
            await _dbContext.SaveChangesAsync();
        }
    }
}
