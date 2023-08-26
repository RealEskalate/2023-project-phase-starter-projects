using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Persistence;
public interface IPostRepository : IGenericRepository<Post>
{
    public Task<List<Post>> GetPostsByUserIdAsync(int userId);
    public Task<List<Post>> GetPostsByTagsAsync(List<string> tags);

    public Task<bool> ExistsAsync(int id);
}
