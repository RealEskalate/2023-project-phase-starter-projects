using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SocialMediaAppDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("SocialMediaAppConnection")));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped <IUserRepository,UserRepository > ();
        services.AddScoped <IPostRepository, PostRepository > ();
        services.AddScoped < ICommentRepository, CommentRepository > ();
        services.AddScoped <IFollowRepository, FollowRepository > ();
        services.AddScoped <ILikeRepository, LikeRepository  > ();
        services.AddScoped <INotificationRepository, NotificationRepository  > ();

        return services;
    }
}
