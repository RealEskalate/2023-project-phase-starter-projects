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
            entity.HasMany(u => u.NotificationsReceived).WithOne(u => u.Recepient);
            entity.HasMany(u => u.NotificationsSent).WithOne(u => u.Sender);
            entity.Property(u => u.CreatedAt).IsRequired();
            entity.Property(u => u.LastModified).IsRequired();
            entity.HasMany(u => u.NotificationsReceived).WithOne(n => n.Recepient);
            entity.HasMany(u => u.NotificationsSent).WithOne(n => n.Sender);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Posts");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Content).IsRequired();

            entity.Property(e => e.UserId).IsRequired();

            entity.Property(e => e.CreatedAt).IsRequired();

            entity.Property(e => e.LastModified).IsRequired();

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

            entity
                .HasMany(e => e.Notifications)
                .WithOne(n => n.Post)
                .HasForeignKey(n => n.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Interaction>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.CreatedAt);
            entity.Property(i => i.LastModified);
        });



        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notifications");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.NotificationType).IsRequired();

            entity.Property(e => e.CreatedAt).IsRequired();

            entity.Property(e => e.LastModified).IsRequired();

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

            entity
                .HasOne(e => e.Post)
                .WithMany(p => p.Notifications)
                .HasForeignKey(n => n.PostId)
                .OnDelete(DeleteBehavior.SetNull);
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