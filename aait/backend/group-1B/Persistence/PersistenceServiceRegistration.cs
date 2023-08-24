using Application.Contracts.Auth;
using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repositories.Auth;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Persistence.Repositories;

=======
>>>>>>> 34d78df (add(AAiT-backend-1A) : add follow and unfollow with the unit tests)
namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SocialSyncDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("SocialSyncDatabase"));
            }
            );

           

            services.AddScoped<IAuthService, AuthService>();
<<<<<<< HEAD
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostLikesRepository, PostLikesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
=======
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IPostLikesRepository, PostLikeRepository>();

>>>>>>> 34d78df (add(AAiT-backend-1A) : add follow and unfollow with the unit tests)

            return services;
        }
    }
}
