using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public class SocialSyncFactory : IDesignTimeDbContextFactory<SocialSyncDbContext>
{
    public SocialSyncDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../WebApi")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<SocialSyncDbContext>();
        var connectionString = configuration.GetConnectionString("SocialSyncDatabase");

        builder.UseNpgsql(connectionString);

        return new SocialSyncDbContext(builder.Options);
    }
}