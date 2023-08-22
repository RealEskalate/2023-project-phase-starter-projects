using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<List<Comment>> GetByPostId(int postId);
}