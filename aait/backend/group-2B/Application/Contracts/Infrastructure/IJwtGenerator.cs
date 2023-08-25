using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Infrastructure;

public interface IJwtGenerator
{
    public string Generate(User user);
}
