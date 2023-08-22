using Microsoft.EntityFrameworkCore;

namespace SocialSync.Persistence;

public class SocialSyncDbContext : DbContext
{
    public SocialSyncDbContext(DbContextOptions<SocialSyncDbContext> options)
        : base(options) { }
}
