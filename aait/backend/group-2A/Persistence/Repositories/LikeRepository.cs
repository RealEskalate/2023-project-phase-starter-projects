using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repository;

public class LikeRepository : ILikeRepository{
    private readonly SocialSyncDbContext _dbContext;
    private readonly DbSet<Like> _dbLikes;

    public LikeRepository(SocialSyncDbContext context){
        _dbContext = context;
        _dbLikes = context.Set<Like>();
    }
    public async Task<List<UserDto>> Likers(int id){
        var likers = await _dbLikes
            .Where(like => like.PostId == id)
            .Select(like => new UserDto
            {
                Id = like.User.Id,
                FullName = like.User.FullName,
                UserName = like.User.UserName
            })
            .ToListAsync();
        return likers;
    }

    public async Task<bool> isLiked(Like like){
        return await _dbLikes.AnyAsync(l => l.PostId == like.PostId && l.UserId == like.UserId);
    }

    public async Task LikePost(Like like){
        await _dbLikes.AddAsync(like);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UnlikePost(Like like){
        _dbLikes.Remove(like);
        await _dbContext.SaveChangesAsync();
    }
}