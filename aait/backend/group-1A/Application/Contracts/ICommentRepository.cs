
using System.Linq.Expressions;
using Application.DTO.CommentDTO.DTO;
using Domain.Entities;

namespace Application.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<Comment> Get(int id);

        Task<List<CommentResponseDTO>> GetByPostId(int postId);

        Task<List<CommentResponseDTO>> GetAllCommentsWithReaction(int userId);

        Task<bool> Exists(int id);

        Task<List<Comment>> GetAll(int userId);
    }
}
