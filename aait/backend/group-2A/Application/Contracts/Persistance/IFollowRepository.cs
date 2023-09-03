using Application.DTO.UserDTO;
using Domain.Entities;

namespace Application.Contracts.Persistance;

public interface IFollowRepository{

    Task<List<User>> GetFollowing(int id, int pageNumber = 0, int pageSize = 10);
    Task<List<User>> GetFollower(int id, int pageNumber = 0, int pageSize = 10);
    Task Follow(Follow follow);
    Task Unfollow(Follow Unfollow);
    Task<bool> FollowRelationshipExists(int followerId, int followedId);

}
