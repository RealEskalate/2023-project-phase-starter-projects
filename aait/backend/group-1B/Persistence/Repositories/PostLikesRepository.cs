using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class PostLikesRepository : IPostLikesRepository
{
    private readonly SocialSyncDbContext _context;

    public PostLikesRepository(SocialSyncDbContext context)
    {
        _context = context;
    }
    
    public async Task<PostLike?> Get(int userId, int postId)
    {
        return await _context.PostLikes.FindAsync(userId, postId);
    }

    public async Task<bool> Exists(int userId, int postId)
    {
        var like = await Get(userId, postId);
        if (like != null)
            _context.Entry(like).State = EntityState.Detached;
        
        return like != null;
    }

    public async Task Delete(PostLike like)
    {
        _context.PostLikes.Remove(like);
        await _context.SaveChangesAsync();
    }

    public async Task<PostLike> Add(PostLike like)
    {
        await _context.PostLikes.AddAsync(like);
        await _context.SaveChangesAsync();
        return like;
    }

    // Returns 1 if it likes and 0 if it dislikes
    public async Task<int> ChangeLike(PostLike like)
    {
        var exists = await Exists(like.UserId, like.PostId);
        if (exists)
        {
            await Delete(like);
            return 0;
        }
        else
        {
            await Add(like);
            return 1;
        }
    }

    public async Task<List<PostLike>> GetLikesByPostId(int postId)
    {
        return await _context.PostLikes
            .Where(like => like.PostId == postId).ToListAsync();
    }

    public async Task<List<PostLike>> GetLikesByUserId(int userId)
    {
        return await _context.PostLikes
            .Where(like => like.UserId == userId).ToListAsync();
    }
}