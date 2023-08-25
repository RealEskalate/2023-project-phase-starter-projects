using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly SocialMediaDbContext _dbContext;

        public PostRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Post> Get(int id, int userId)
        {
            var result = await _dbContext.Posts
                    .Include(x => x.Comments)
                    .Include(x => x.PostReactions)
                    .Where(x => x.Id == id && x.UserId == userId)
                    .SingleOrDefaultAsync();
            return result;
        }
    }
}
