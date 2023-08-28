namespace SocialSync.Application.Contracts.Infrastructure;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}
