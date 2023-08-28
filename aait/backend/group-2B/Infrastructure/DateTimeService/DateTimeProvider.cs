using SocialSync.Application.Contracts.Infrastructure;

namespace SocialSync.Infrastructure.DateTimeService;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
