using Domain.Entities;
using System.Collections.Generic;
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
