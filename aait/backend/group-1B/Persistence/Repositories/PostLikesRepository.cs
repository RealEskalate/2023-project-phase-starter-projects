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
        return like;
    }

    public async Task ChangeLike(PostLike like)
    {
        var exists = await Exists(like.UserId, like.PostId);
        if (exists)
            await Delete(like);
        else
            await Add(like);
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