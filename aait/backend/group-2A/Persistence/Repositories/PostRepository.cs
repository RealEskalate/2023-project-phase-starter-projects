using Application.Contracts.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repository;

public class PostRepository: GenericRepository<Post>, IPostRepository
{
    private readonly SocialSyncDbContext _dbContext;
    private readonly DbSet<Post> _dbPostSet;
    private readonly DbSet<User> _dbUserSet;

    public PostRepository(SocialSyncDbContext context) : base(context)
    {
        _dbContext = context;
        _dbPostSet = _dbContext.Set<Post>();
        _dbUserSet = _dbContext.Set<User>();
    }

    public Task<List<Post>> GetBytag(string tags){
        throw new NotImplementedException();
    }

    public Task<List<Post>> GetFollowingPost(int id){
        throw new NotImplementedException();
    }

    public Task<List<Post>> GetByContent(string tags){
        throw new NotImplementedException();
    }

    public Task<List<Post>> GetUserPost(int id){
        throw new NotImplementedException();
    }
    
}