using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts;

public interface IAuthRepository{

    Task<User> RegisterUser(User user);

    Task<User> LoginUser(User user);

    Task<bool> UserExists(string username);

}