namespace SocialSync.Application.Contracts.Infrastructure;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
