using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts;
public interface IJwtGenerator
{
    Task<string> CreateTokenAsync(User user);
}