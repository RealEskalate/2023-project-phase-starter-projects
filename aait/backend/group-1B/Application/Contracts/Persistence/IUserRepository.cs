
using Domain.Entities;

namespace Application.Contracts.Persistence;



public interface IUserRepository
{
    Task<bool> FollowUser(int followerId, int followeeId);

    Task<bool> UnFollowUser(int followerId, int followeeId);

    Task<List<User>> GetUsers(int userId, bool getFollower);

    Task UpdateUser(User user);

    Task<User?> GetUserDetail(int userId);


    Task<bool> Exists(int userId);

}