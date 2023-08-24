using Application.Contracts.Persistence;
using Domain.Entities;

namespace Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(SocialSyncDbContext context) : base(context)
    {
    }
}