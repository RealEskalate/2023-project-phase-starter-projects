using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class SocialSyncDbContext : DbContext
{
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Like> Likes { get; set; }
    public virtual DbSet<Follow> Follows { get; set; }
    public virtual DbSet<Notification> Notifications{ get; set; }

    public SocialSyncDbContext(DbContextOptions<SocialSyncDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<User>(
            entity => {
                entity
                    .Property(e => e.Id)
                    .UseIdentityColumn();
                entity
                    .Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
                entity
                    .Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'")
                    .ValueGeneratedOnUpdate();
                entity
                    .HasMany(e => e.Posts)
                    .WithOne(e => e.User);
                
                entity
                    .HasMany(e => e.Likes)
                    .WithOne(e => e.User);
                
                entity
                    .HasMany(e => e.Comments)
                    .WithOne(e => e.User);
                
                entity.Property(e => e.FullName)
                    .IsRequired();
                
                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasIndex(e => e.UserName).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                
            }
        );
   
        modelBuilder.Entity<Follow>(
            entity => {
                entity
                    .HasKey(e => new{ e.FollowedId, e.FollowerId });
                entity
                    .HasOne(e => e.Follower)
                    .WithMany(u => u.Followee)
                    .HasForeignKey(e => e.FollowerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Follower_User");
                entity
                    .HasOne(e => e.Followed)
                    .WithMany(u => u.Follower)
                    .HasForeignKey(e => e.FollowedId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Followed_User");
                
            }
        );
        
        modelBuilder.Entity<Post>(
            entity => {
                entity
                    .Property(e => e.Id)
                    .UseIdentityColumn();
                entity
                    .Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
                entity
                    .Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'")
                    .ValueGeneratedOnUpdate();
                entity
                    .HasOne(e => e.User)
                    .WithMany(e => e.Posts);
                entity
                    .HasMany(e => e.Comments)
                    .WithOne(e => e.Post);
                entity
                    .Property(e => e.Content)
                    .IsRequired();
                entity
                    .Property(e => e.UserId)
                    .IsRequired();
            }
        );
        modelBuilder.Entity<Comment>(
            entity => {
                entity
                    .Property(e => e.Id)
                    .UseIdentityColumn();
                entity
                    .Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
                entity
                    .Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'")
                    .ValueGeneratedOnUpdate();
                entity
                    .HasOne(e => e.Post)
                    .WithMany(e => e.Comments)
                    .HasForeignKey(e => e.PostId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Comment_Post");
                entity
                    .HasOne(e => e.User)
                    .WithMany(e => e.Comments)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Comment_User");
                entity
                    .Property(e => e.Content)
                    .IsRequired();
                entity
                    .Property(e => e.UserId)
                    .IsRequired();
                entity
                    .Property(e => e.PostId)
                    .IsRequired();
            }
        );

        modelBuilder.Entity<Like>(
            entity => {
                entity
                    .HasKey(e => new{ e.PostId, e.UserId });
                entity
                    .HasOne(e => e.User)
                    .WithMany(e => e.Likes)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Like_User");
                entity
                    .HasOne(e => e.Post)
                    .WithMany(e => e.Likes)
                    .HasForeignKey(e => e.PostId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Like_Post");
            }
        );
        
        modelBuilder.Entity<Notification>(
            entity => {
                entity
                    .Property(e => e.Id)
                    .UseIdentityColumn();
                entity
                    .Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
                entity
                    .HasOne(e => e.User)
                    .WithMany(e => e.Notifications);
                entity
                    .Property(e => e.Message)
                    .IsRequired();
                entity
                    .Property(e => e.UserId)
                    .IsRequired();
            }
        );
        
        

    }
    
}