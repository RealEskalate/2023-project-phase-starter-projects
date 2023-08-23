using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistence.Repositories;

public class InteractionRepository : GenericRepository<Interaction>, IInteractionRepository
{
    public InteractionRepository(SocialSyncDbContext dbContext)
        : base(dbContext) { }
}
