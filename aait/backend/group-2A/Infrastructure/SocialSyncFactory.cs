using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class SocialSyncFactory : IDesignTimeDbContextFactory<UserIdentityDbContext>
{
    public UserIdentityDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../WebApi")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<UserIdentityDbContext>();
        var connectionString = configuration.GetConnectionString("SocialSync");

        builder.UseNpgsql(connectionString);

        return new UserIdentityDbContext(builder.Options);
    }
}