
using Domain.Entities;
namespace Application.Contracts.Persistance;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<List<Comment>> GetCommentByPost(int id, int pageNumber = 0, int pageSize = 10);
}