using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistance.Repository;

public class FollowRepository : IFollowRepository
{
    private readonly SocialSyncDbContext _dbContext;
    
    public FollowRepository(SocialSyncDbContext context){
        _dbContext = context;
    }

    public async Task Follow(Follow follow){
        await _dbContext.Follows.AddAsync(follow);
    }

    public async Task Unfollow(Follow Unfollow){
        _dbContext.Follows.Remove(Unfollow);
    }

    public async Task<List<User>> GetFollower(int id, int pageNumber = 0, int pageSize = 10){
        var followers = await _dbContext.Follows
            .Where(f => f.FollowedId == id)
            .Select(f => f.Follower)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return followers;
    }

    public async Task<List<User>> GetFollowing(int id, int pageNumber = 0, int pageSize = 10){
        var following = await _dbContext.Follows
            .Where(f => f.FollowerId == id)
            .Select(f => f.Followed)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return following;
    }

    public async Task<bool> FollowRelationshipExists(int followerId, int followedId)
    {
        return await _dbContext.Follows
            .AnyAsync(f => f.FollowerId == followerId && f.FollowedId == followedId);
    }
}