using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<List<Post>> GetPostsFromFollowing(int userId);
    Task<List<Post>> GetByTag(string tag);
    Task<List<Post>> GetByUserId(int userId);
}