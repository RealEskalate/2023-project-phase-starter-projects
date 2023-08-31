


using Application.DTO.UserDTO;
using Domain.Entities;

namespace Application.Contracts.Persistance;

public interface ILikeRepository
{
    Task<bool> isLiked(Like like);
    Task<List<User>> GetLikers(int id, int pageNumber=0, int pageSize = 10);
    Task LikePost(Like like);
    Task UnlikePost(Like like);
    Task<List<Post>> GetLikedPost(int Id, int pageNumber=0, int pageSize = 10);

}