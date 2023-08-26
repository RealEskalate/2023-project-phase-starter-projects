using Microsoft.EntityFrameworkCore;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistence.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    private readonly SocialSyncDbContext _dbContext;

    public PostRepository(SocialSyncDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Post>> GetPostsByTagsAsync(List<string> tags)
    {
        var matchingPosts = new List<Post>();

        await foreach (var post in _dbContext.Posts.AsAsyncEnumerable())
        {
            if (tags.Any(tag => post.Content.Contains(tag)))
            {
                matchingPosts.Add(post);
            }
        }

        return matchingPosts;
    }


    public async Task<List<Post>> GetPostsByUserIdAsync(int userId)
    {
        var postsByUser = await _dbContext.Posts
            .Where(post => post.UserId == userId)
            .ToListAsync();

        return postsByUser;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        var post = await _dbContext.Posts
                        .FindAsync(id);

        return post != null;


    }

}
