


using Domain.Entities;
namespace Application.Contracts.Persistance;

public interface ILikeRepository : IGenericRepository<Like>
{
    Task<Like> GetLikedPost(int id);
    Task LikePost(Like like);
}