using Microsoft.EntityFrameworkCore;
using SocialSync.Domain.Common;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistence;

public class SocialSyncDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<Interaction> Interactions { get; set; } = null!;

    public SocialSyncDbContext(DbContextOptions<SocialSyncDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.HasMany(u => u.Followers).WithMany(u => u.Followings);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Posts");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Content).IsRequired();

            entity.Property(e => e.UserId).IsRequired();

            entity
                .HasOne(e => e.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasMany(e => e.Interactions)
                .WithOne(i => i.Post)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Interaction>().HasKey(i => i.Id);

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notifications");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.NotificationType).IsRequired();

            entity
                .HasOne(e => e.Recepient)
                .WithMany(u => u.NotificationsReceived)
                .HasForeignKey(e => e.RecepientId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(e => e.Sender)
                .WithMany(u => u.NotificationsSent)
                .HasForeignKey(e => e.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            entry.Entity.LastModified = DateTime.Now.ToUniversalTime();
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now.ToUniversalTime();
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
}






