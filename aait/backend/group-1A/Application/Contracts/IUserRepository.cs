using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts;

public interface IUserRepository
{
    Task<User> RegisterUserAsync(User user, string password);
    Task<User> LoginUserAsync(string email, string password);
    Task<bool> UserExistsAsync(string email);

    Task<bool> ChangePasswordAsync(User user, string oldPassword, string newPassword);

    Task<bool> UpdateUserAsync(User user);

    Task<bool> DeleteUserAsync(User user);
}