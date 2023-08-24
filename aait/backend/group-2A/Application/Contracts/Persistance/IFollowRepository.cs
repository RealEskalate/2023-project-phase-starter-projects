using Application.DTO.UserDTO;
using Domain.Entities;

namespace Application.Contracts.Persistance;

public interface IFollowRepository{

    Task<List<User>> GetFollowing(int id);
    Task<List<User>> GetFollower(int id);
    Task Follow(Follow follow);
    Task Unfollow(Follow Unfollow);

}
