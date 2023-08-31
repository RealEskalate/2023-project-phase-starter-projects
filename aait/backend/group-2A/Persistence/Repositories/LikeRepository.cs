using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistance.Repository;

public class LikeRepository : ILikeRepository{
    private readonly SocialSyncDbContext _dbContext;


    public LikeRepository(SocialSyncDbContext context){
        _dbContext = context;

    }
    public async Task<List<User>> GetLikers(int id, int pageNumber = 0, int pageSize = 10){
        var likers = await _dbContext.Likes
            .Where(like => like.PostId == id)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .Select(like => like.User)
            .ToListAsync();
        return likers;
    }

    public async Task<bool> isLiked(Like like){
        return await _dbContext.Likes.AnyAsync(l => l.PostId == like.PostId && l.UserId == like.UserId);
    }
    public async Task<List<Post>> GetLikedPost(int Id, int pageNumber = 0, int pageSize = 10){
        var postsLikedByUser = await _dbContext.Posts
            .Join(_dbContext.Likes,
                post => post.Id,
                like => like.PostId,
                (post, like) => new { Post = post, Like = like })
            .Where(joinResult => joinResult.Like.UserId == Id)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .Select(joinResult => joinResult.Post)
            .ToListAsync();

        return postsLikedByUser;
        
    }

    public async Task LikePost(Like like){
        await _dbContext.Likes.AddAsync(like);
    }


    public async Task UnlikePost(Like like){
        _dbContext.Likes.Remove(like);
    }
}