using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly SocialSyncDbContext _dbContext;

    public UserRepository(SocialSyncDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> EmailExists(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UsernameExists(string username)
    {
        throw new NotImplementedException();
    }
}
