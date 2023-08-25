using Application.DTO.PostDTO.DTO;
using Domain.Entities;
using System.Linq.Expressions;


namespace Application.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post> Get(int id, int userId);

        Task<List<PostResponseDTO>> GetAllPostsWithReaction(Expression<Func<Post, bool>> predicate, int userId);

        Task<bool> Exists(int id);
    }
}
