using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class SocialSyncDbContext : DbContext
{
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Like> Likes { get; set; }
    public virtual DbSet<Follow> Follows { get; set; }
        
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
                
                // entity
                //     .HasMany(e => e.Likes)
                //     .WithMany(e => e.User)
                //     .
                
                entity
                    .HasMany(e => e.Comments)
                    .WithOne(e => e.User);
                
            }
        );
        // Not Sure
        modelBuilder.Entity<Follow>(
            entity => {
                entity
                    .HasOne(e => e.Follower)
                    .WithMany(u => u.Follower)
                    .HasForeignKey(e => e.FollowerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Follower_User");

                entity
                    .HasOne(e => e.Following)
                    .WithMany(u => u.Following)
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
                    .HasConstraintName("FK_Comment_Post");
            }
        );

        modelBuilder.Entity<Like>(
            entity => {
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


    }
    
}