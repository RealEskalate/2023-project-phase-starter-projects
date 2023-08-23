using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(SocialSyncDbContext dbContext)
        : base(dbContext) { }
}
