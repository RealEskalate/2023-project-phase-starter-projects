using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialSync.Application.Contracts.Infrastructure;
using SocialSync.Infrastructure.DateTimeService;
using SocialSync.Infrastructure.JWT;

namespace SocialSync.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection RegiserInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        return services;
    }
}
