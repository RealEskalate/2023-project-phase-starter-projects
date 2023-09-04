using Microsoft.AspNetCore.Authentication.JwtBearer; 
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Contracts.Identity;
using Application.Model;
using Microsoft.EntityFrameworkCore;
using Persistence.Model;
using Persistence.Service;

namespace Persistence
{ 
    public static class InfrastuctureServices 
    { 
 
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) { 
 
    
            // to get jwtsettings from appsettings.json in api project 
            services.Configure<JwtSetting>(configuration.GetSection("JwtSetting")); 
 
            // to use sql server 
            services.AddDbContext<UserIdentityDbContext>(options => {
                    options.UseNpgsql(configuration.GetConnectionString("SocialSync"));
                }
            ); 
 
            // to add identityRole to the AppUser 
            services.AddIdentity<ApplicaionUser, IdentityRole>().AddEntityFrameworkStores<UserIdentityDbContext>().AddDefaultTokenProviders(); 
 
 
            // to register the auth service for IAuthService 
            services.AddTransient<IAuthService, AuthService>(); 
 
            // to add authentication to services container 
            services.AddAuthentication( 
                options => 
                 { 
                     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
                 } 
                ).AddJwtBearer( 
                        o => { 
 
                            o.TokenValidationParameters = new TokenValidationParameters 
                            { 
 
                                ValidateIssuerSigningKey = true, 
                                ValidateIssuer = true, 
                                ValidateAudience = true, 
                                ValidateLifetime = true, 
                                ClockSkew = TimeSpan.Zero, 
                                ValidIssuer = configuration["JwtSetting:Issuer"], 
                                ValidAudience = configuration["JwtSetting:Audience"], 
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"])) 
                            }; 
 
 
                        } 
                ); 
 
            return services; 
 
     
        } 
    } 
}