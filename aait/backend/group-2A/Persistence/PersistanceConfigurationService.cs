using Application.Contracts.Persistance;
using Infrastructure.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class PersistanceConfigurationService{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext< SocialSyncDbContext > (options => {
            options.UseNpgsql(configuration.GetConnectionString("SocialSync"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IFollowRepository, FollowRepository>();
        services.AddScoped<ILikeRepository, LikeRepository>();
        return services;
    }
    
}