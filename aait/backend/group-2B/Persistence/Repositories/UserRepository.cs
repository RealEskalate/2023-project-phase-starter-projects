using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace SocialSync.Persistence.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly SocialSyncDbContext _dbContext;
    public UserRepository(SocialSyncDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> EmailExists(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email == email);
    }



    public async Task<User> GetByUsername(string username)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Username == username);
        return user!;
    }



    public async Task<bool> UsernameExists(string username)
    {
        return await _dbContext.Users.AnyAsync(user => user.Username == username);
    }


    public async Task FollowUser(int follower, int followed)
    {
        var followerUser = await _dbContext.Users.FindAsync(follower);

        var followedUser = await _dbContext.Users.FindAsync(followed);

        if (followerUser != null && followedUser != null)
        {
            followerUser.Followings.Add(followedUser);
            followedUser.Followers.Add(followerUser);

        }

    }

    public async Task UnfollowUser(int follower, int followed)
    {
        var followerUser = await _dbContext.Users.FindAsync(follower);
        var followedUser = await _dbContext.Users.FindAsync(followed);

        if (followedUser != null && followerUser != null)
        {
            followerUser.Followings.Remove(followedUser);
            followedUser.Followers.Remove(followerUser);
        }

    }
}
