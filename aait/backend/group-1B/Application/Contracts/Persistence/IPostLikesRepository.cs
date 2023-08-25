using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IPostLikesRepository
{
    Task<PostLike?> Get(int userId, int postId);
    Task<bool> Exists(int userId, int postId);
    Task Delete(PostLike like);
    Task<PostLike> Add(PostLike like);
    Task<int> ChangeLike(PostLike like);
    Task<List<PostLike>> GetLikesByPostId(int postId);
    Task<List<PostLike>> GetLikesByUserId(int userId);
}