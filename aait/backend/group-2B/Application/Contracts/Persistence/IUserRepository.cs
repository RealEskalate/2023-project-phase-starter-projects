using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> UsernameExists(string username);
    public Task<bool> EmailExists(string email);
    public Task<User> GetByUsername(string username);

    public Task FollowUser (int follower , int follewed);
    public Task UnFollowUser (int follower, int follewed);
    
}
