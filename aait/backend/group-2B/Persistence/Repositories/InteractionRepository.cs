using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistence.Repositories;

public class InteractionRepository : GenericRepository<Interaction>, IInteractionRepository
{
    private readonly SocialSyncDbContext _dbContext;

    public InteractionRepository(SocialSyncDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
