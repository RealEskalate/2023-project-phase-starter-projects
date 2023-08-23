using Application.DTO.CommentReactionDTOS.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ICommentReactionRepository : IGenericRepository<CommentReaction>
    {
        Task<List<CommentReaction>> GetReactionsForCommentAsync(int commentId);
        Task<List<CommentReaction>> GetReactionsByUserAsync(int userId);
        Task<CommentReaction> GetCommentReactionByIdAsync(int id);
        Task<List<CommentReactionDTO>> GetAllCommentReactionsAsync();
        Task AddCommentReactionAsync(CommentReaction commentReaction);
        Task UpdateCommentReactionAsync(CommentReaction existingCommentReaction);
        Task DeleteCommentReactionAsync(int id);
    }
}
