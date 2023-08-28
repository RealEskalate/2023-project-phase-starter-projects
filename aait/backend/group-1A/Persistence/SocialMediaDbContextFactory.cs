using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class SocialMediaDbContextFactory : IDesignTimeDbContextFactory<SocialMediaDbContext>
    {
        public SocialMediaDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/../WebApi")
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<SocialMediaDbContext>();
            var connectionString = configuration.GetConnectionString("SocialMediaApp");

            builder.UseNpgsql(connectionString);
            builder.EnableSensitiveDataLogging();


            return new SocialMediaDbContext(builder.Options);
        }
    }
}
