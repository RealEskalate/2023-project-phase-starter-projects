
using Domain.Entities;
namespace Application.Contracts.Persistance;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<List<Comment>> GetCommentByPost(int id);
}