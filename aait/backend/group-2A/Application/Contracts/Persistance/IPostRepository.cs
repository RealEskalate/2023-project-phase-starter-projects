



using Domain.Entities;
namespace Application.Contracts.Persistance;
public interface IPostRepository : IGenericRepository<Post>
{
    Task<List<Post>> GetFollowingPost(int id);
    Task<List<Post>> GetUserPost(int id);
    Task<List<Post>> GetBytag(string tags);
    Task<List<Post>> GetByContent(string tags);
}