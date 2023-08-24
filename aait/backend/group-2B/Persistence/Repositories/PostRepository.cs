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

    public async Task<IReadOnlyList<Post>> GetPostsByTagsAsync(List<string> tags)
    {
        List<Post> postsByTags = await _dbContext.Posts
                                .Where(post => tags.Any(tag => post.Content.Contains(tag)))
                                .ToListAsync();

        return postsByTags.AsReadOnly();
    }

    public async Task<IReadOnlyList<Post>> GetPostsByUserIdAsync(int userId)
    {
        var postsByUser = await _dbContext.Posts
            .Where(post => post.UserId == userId)
            .ToListAsync();

        return postsByUser.AsReadOnly();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        var post = await _dbContext.Posts
                        .FindAsync(id);

        return post != null;


    }

}
