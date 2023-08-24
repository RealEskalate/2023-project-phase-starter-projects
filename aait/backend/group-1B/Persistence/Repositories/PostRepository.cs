using Application.Contracts.Persistence;
using Application.Features.Comments.Requests.Queries;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(SocialSyncDbContext context) : base(context)
    {
    }
    
    public async Task<List<Post>> GetByTag(string tagName)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagName);
        if (tag == null)
            return new List<Post>();
        
        var tagId = tag.Id;

        var query = from post in _context.Posts
            join postId in
                (from pTag in _context.PostTags 
                    where pTag.TagId == tagId 
                    select pTag.PostId)
                on post.Id equals postId
            select post;

        var posts = await query.ToListAsync();
        return posts;
    }

    public async Task<List<Post>> GetByUserId(int userId)
    {
        var posts = await _context.Posts
            .Where(post => post.UserId == userId).ToListAsync();

        return posts;
    }

    public async Task<List<Post>> GetPostsFromFollowing(int userId)
    {
        var query = from post in _context.Posts
            where (from follow in _context.Follows where follow.FollowerId == userId select follow.FolloweeId)
                .Contains(post.UserId)
            select post;

        return await query.ToListAsync();
    }
}