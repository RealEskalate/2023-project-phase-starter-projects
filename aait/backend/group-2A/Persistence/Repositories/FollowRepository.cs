using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Domain.Entities;

namespace Infrastructure.Persistance.Repository;

public class FollowRepository : IFollowRepository
{
    private readonly SocialSyncDbContext _dbContext;
    
    public FollowRepository(SocialSyncDbContext context){
        _dbContext = context;
    }

    public Task Follow(Follow follow){
        throw new NotImplementedException();
    }

    public Task Unfollow(Follow Unfollow){
        throw new NotImplementedException();
    }

    public Task<List<UserDto>> GetFollower(int id){
        throw new NotImplementedException();
    }

    public Task<List<UserDto>> GetFollowing(int id){
        throw new NotImplementedException();
    }
}