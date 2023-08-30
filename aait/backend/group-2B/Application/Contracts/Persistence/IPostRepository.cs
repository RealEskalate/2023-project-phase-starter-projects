using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Persistence;
public interface IPostRepository : IGenericRepository<Post>
{
    public Task<IReadOnlyList<Post>> GetPostsByUserIdAsync(int userId);
    public Task<IReadOnlyList<Post>> GetFeedsByUserIdAsync(int userID);
    public Task<IReadOnlyList<Post>> GetPostsByTagsAsync(List<string> tags);
    public Task<bool> ExistsAsync(int id);
    public Task LikePostAsync(int id);
    public Task UnlikePostAsync(int id);
}
