using Microsoft.EntityFrameworkCore;
using SocialSync.Domain.Common;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistence;

public class SocialSyncDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Interaction> Interactions { get; set; }
    public SocialSyncDbContext(DbContextOptions<SocialSyncDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Followings)
                .UsingEntity<Dictionary<string, object>>(
                    "UserFollow",
                    j => j.HasOne<User>().WithMany(),
                    j => j.HasOne<User>().WithMany(),
                    j =>
                    {
                        j.HasKey("FollowerId", "FollowingId");
                        j.ToTable("UserFollows");
                    }
                );
        }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
        {
            entry.Entity.LastModified = DateTime.Now.ToUniversalTime();
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now.ToUniversalTime();
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


    }

}






