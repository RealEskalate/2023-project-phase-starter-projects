using Application.DTO.UserDTO;
using Domain.Entities;

namespace Application.Contracts.Persistance;

public interface IFollowRepository{

    Task<List<UserDto>> GetFollowing(int id);
    Task<List<UserDto>> GetFollower(int id);
    Task Follow(Follow follow);
    Task Unfollow(Follow Unfollow);

}
