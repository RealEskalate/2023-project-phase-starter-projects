using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Persistence.Repositories;

namespace SocialSync.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<SocialSyncDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConn"));
        });
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
