



using Domain.Entities;
namespace Application.Contracts.Persistance;
public interface IPostRepository : IGenericRepository<Post>
{
    Task<List<Post>> GetFollowingPost(int id, int pageNumber=0, int pageSize = 10);
    Task<List<Post>> GetUserPost(int id, int pageNumber=0, int pageSize = 10);
    Task<List<Post>> GetBytag(string tags,int pageNumber=0, int pageSize = 10);
    Task<List<Post>> GetByContent(string tags,int pageNumber=0, int pageSize = 10);
}