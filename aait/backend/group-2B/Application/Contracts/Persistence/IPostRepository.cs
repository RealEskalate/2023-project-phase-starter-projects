using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Persistence;
public interface IPostRepository : IGenericRepository<Post>
{
    public Task<IReadOnlyList<Post>> GetPostsByUserId(int userId);
    public Task<IReadOnlyList<Post>> GetPostsByTags(List<string> tags);

    public Task<bool> Exists(int Id);
}
