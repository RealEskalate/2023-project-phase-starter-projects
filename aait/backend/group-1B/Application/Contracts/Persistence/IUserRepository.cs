using Domain.Entities;

namespace Application.Contracts.Persistence;

    

    public interface IUserRepository
{
    Task<bool> FollowUser(int followerId, int followeeId);

    Task<bool> UnFollowUser(int followerId, int followeeId);

    Task<List<User>> GetUsers(int userId, bool getFollower);

    Task UpdateUser(User user);

    Task<User?> GetUserDetail(int userId);

<<<<<<< HEAD
    Task<bool> Exists(int UserId);
=======
    Task<bool> Exists(int userId); 
>>>>>>> 34d78df (add(AAiT-backend-1A) : add follow and unfollow with the unit tests)

   }