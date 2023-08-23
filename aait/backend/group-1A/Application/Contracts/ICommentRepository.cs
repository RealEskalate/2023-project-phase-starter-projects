using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetCommentsForPostAsync(int postId);
        Task<List<Comment>> GetCommentsByUserAsync(int userId);

        // Define other methods specific to comments
    }
}
