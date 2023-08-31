using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repositories.CommentRespositories;
using SocialSync.Application.Contracts;
using SocialSync.Persistence.Repositories.Auth;
using Persistence.Repositories.ReactionRespositories;
using SocialSync.Persistnece.Repositories;


namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SocialMediaDbContext>(opt =>
                 opt.UseNpgsql(configuration.GetConnectionString("SocialMediaApp")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostReactionRepository, PostReactionRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>(); // Add this line
            services.AddScoped<ICommentReactionRepository, CommentReactionRepository>(); // Add this line
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<ICommentReactionRepository, CommentReactionRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped<ITagRepository,TagReposiotry>();
            services.AddScoped<IPostTagRepository,PostTagRepository>();
            services.AddScoped<IAuthRepository,AuthRepository>();
            services.AddScoped<IJwtGenerator,JwtGenerator>();

            return services;
        }
    }
}

