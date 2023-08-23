using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistence.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(SocialSyncDbContext dbContext)
        : base(dbContext) { }
}
