using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories;
using System.Reflection;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SocialMediaDbContext>(opt =>
                 opt.UseNpgsql(configuration.GetConnectionString("SocialMediaApp")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericReactionRepository<>), typeof(GenericReactionRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostReaction, PostReactionRepository>();

            return services;
        }
    }
}



//