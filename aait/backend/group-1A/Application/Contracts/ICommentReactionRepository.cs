using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ICommentReactionRepository : IGenericRepository<CommentReaction>
    {
        Task<List<CommentReaction>> GetReactionsForCommentAsync(int commentId);
        Task<List<CommentReaction>> GetReactionsByUserAsync(int userId);

        // Define other methods specific to comment reactions
    }
}
