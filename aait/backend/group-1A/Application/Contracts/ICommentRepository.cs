using Application.DTO.CommentDTOS.DTO;
using Application.Features.CommentFeatures.Requests.Commands;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetCommentsForPostAsync(int postId);
        Task<List<Comment>> GetCommentsByUserAsync(int userId);
        Task<CommentDTO> GetCommentByIdAsync(int commentId);
        Task<List<CommentDTO>> GetAllCommentsAsync();
        Task DeleteCommentAsync(int id);
        Task UpdateCommentAsync(CommentUpdateCommand request);

        // Define other methods specific to comments
    }
}
