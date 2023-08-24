using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repository;

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

    public async Task<List<User>> GetFollower(int id){
        var followers = await _dbContext.Follows
            .Where(f => f.FollowedId == id)
            .Select(f => f.Follower)
            .ToListAsync();

        return followers;
    }

    public async Task<List<User>> GetFollowing(int id){
        var following = await _dbContext.Follows
            .Where(f => f.FollowerId == id)
            .Select(f => f.Followed)
            .ToListAsync();
        return following;
    }
}