using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repository;

public class LikeRepository : ILikeRepository{
    private readonly SocialSyncDbContext _dbContext;


    public LikeRepository(SocialSyncDbContext context){
        _dbContext = context;

    }
    public async Task<List<User>> GetLikers(int id){
        var likers = await _dbContext.Likes
            .Where(like => like.PostId == id)
            .Select(like => like.User)
            .ToListAsync();
        return likers;
    }

    public async Task<bool> isLiked(Like like){
        return await _dbContext.Likes.AnyAsync(l => l.PostId == like.PostId && l.UserId == like.UserId);
    }

    public async Task LikePost(Like like){
        await _dbContext.Likes.AddAsync(like);
    }

    public async Task UnlikePost(Like like){
        _dbContext.Likes.Remove(like);
    }
}