using Application.Common.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfiguringApplicationServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            var key = Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings:Key").Value);
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)              
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return service;

        }
    }
}
