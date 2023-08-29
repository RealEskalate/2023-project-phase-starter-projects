using System.Dynamic;
using System.Security.Cryptography;
using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Persistence.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    private readonly SocialMediaAppDbContext _dbContext;
    public PostRepository(SocialMediaAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Post> GetPostDetails(Guid userId, Guid id)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            var post = await _dbContext.Posts.FindAsync(id);
            if (post != null)
            {
                return post;
            }
        }
        return null;
    }

    public async Task<List<Post>> GetPosts(Guid userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            var posts = await _dbContext.Posts.Where(n => n.UserId == userId).ToListAsync();
            return posts;
        }
        return null;
    }

    public async Task<List<Post>> SearchPosts(string query)
    {
        var posts = await  _dbContext.Posts.ToListAsync();

        List<Post> postResult = new List<Post>();
        foreach (var post in posts)
        {
            if (post.Title.Contains(query) || post.Content.Contains(query))
            {
                postResult.Add(post);
                continue; // Skip the hashtag loop if title or content match
            }

            foreach (var hash in post.HashTag)
            {
                if (hash.Contains(query))
                {
                    postResult.Add(post);
                    break;
                }
            }
        }

        return postResult;

    }
    public async Task<List<Post>> GetPostForNewsFeed(Guid userId)
    {
        return await _dbContext.Posts
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.CreatedDate)
            .ToListAsync();
    }

}
