using Application.Contracts.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistance.Repository;

public class PostRepository: GenericRepository<Post>, IPostRepository
{
    private readonly SocialSyncDbContext _dbContext;
    private readonly DbSet<Post> _dbPostSet;
    private readonly DbSet<Follow> _dbFollowSet;

    public PostRepository(SocialSyncDbContext context) : base(context)
    {
        _dbContext = context;
        _dbPostSet = _dbContext.Set<Post>();
        _dbFollowSet = _dbContext.Set<Follow>();
    }

    public async Task<List<Post>> GetBytag(string tag, int pageNumber = 0, int pageSize = 10){
        return  await _dbPostSet
            .Where(post => post.Tags.Contains(tag))
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Post>> GetFollowingPost(int id,int pageNumber = 0, int pageSize = 10){
        var followingPosts = await _dbFollowSet
            .Where(f => f.FollowerId == id)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .Join(_dbPostSet,
                follow => follow.FollowedId,
                post => post.UserId,
                (follow, post) => post)
            .ToListAsync();
        return followingPosts;
    }

    public async Task<List<Post>> GetByContent(string content,int pageNumber = 0, int pageSize = 10){
        return await _dbPostSet
            .Where(post => EF.Functions.Like(post.Content, "%" + content + "%"))
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Post>> GetUserPost(int id,int pageNumber = 0, int pageSize = 10){
        return await _dbPostSet
            .Where(post => post.UserId == id)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    
}