using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Persistence.Repositories;

public class LikeRepository: GenericRepository<Like>, ILikeRepository
{
    private readonly SocialMediaAppDbContext _dbContext;
    public LikeRepository(SocialMediaAppDbContext dbContext):base (dbContext)
    {
        _dbContext = dbContext;
        
    }

    public async Task<List<Like>> GetLikesById(Guid postId)
    {
        var likes = await _dbContext.Likes.Where(L=>L.PostId == postId).ToListAsync();
        return likes;
    }

    public async Task<bool> LikeExists(Guid UserId, Guid PostId)
    {
        var user = await _dbContext.Likes.Where(n => n.UserId == UserId && n.PostId == PostId).ToListAsync();
        Console.WriteLine(user.IsNullOrEmpty());
        return user.IsNullOrEmpty();
    }

    public async Task<List<Like>> GetLikesByPostId(Guid userId, Guid PostId)
    {
        var likes = await _dbContext.Likes.Where(l => l.PostId == PostId).ToListAsync();
        return likes;
    }
}
