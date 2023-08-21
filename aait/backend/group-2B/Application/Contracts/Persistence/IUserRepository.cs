using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User> {
  public Task<bool> UsernameExists(string username);
  public Task<User> GetByUsername(string username);
}
