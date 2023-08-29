using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IPostTagRepository : IGenericRepository<PostTag>
{
    Task<bool> ExistsByTagName(string tagName);
    Task<int> GetTagId(string tagName);
    Task AddTagToPost(int postId, string tagName);
    //Task<int> GetPostsId(int tagId);
    Task DeletePostTag(int postId, string tagName);
}