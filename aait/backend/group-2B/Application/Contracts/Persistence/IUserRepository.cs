using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> UsernameExists(string username);
    public Task<bool> EmailExists(string email);
    public Task<User> GetByUsername(string username);

    public Task FollowUser(int followerId, int followedId);
    public Task UnfollowUser(int followerId, int unfollowedId);
}
