using Application.DTO.PostDTO.DTO;
using Domain.Entities;
using System.Linq.Expressions;


namespace Application.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post> Get(int id);

        Task<List<PostResponseDTO>> GetAllPostsWithReaction(int userId);

        Task<bool> Exists(int id);

        Task<List<Post>> GetAll(int userId);

        Task<List<Post>> GetByTagName(string tagName);
        Task<List<Post>> GetFeed(int UserId);
    }
}
