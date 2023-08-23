using Application.Contracts.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            return services;
        }
    }
}
