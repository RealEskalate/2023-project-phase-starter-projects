using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Persistence;

<<<<<<< HEAD
public interface IUserRepository : IGenericRepository<User> { }
=======
public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> UsernameExists(string username);
    public Task<bool> EmailExists(string email);
    public Task<User> GetByUsername(string username);
}
>>>>>>> d91c235 (feat(aait.bac.2b.authentication): Add user interface as a contract)
