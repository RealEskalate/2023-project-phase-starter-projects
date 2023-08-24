


using Application.DTO.UserDTO;
using Domain.Entities;
namespace Application.Contracts.Persistance;

public interface ILikeRepository
{
    Task<bool> isLiked(Like like);
    Task<List<User>> Likers(int id);
    Task LikePost(Like like);
    Task UnlikePost(Like like);

}