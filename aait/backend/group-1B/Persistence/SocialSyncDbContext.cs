using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class SocialSyncDbContext : DbContext
    {
        public SocialSyncDbContext(DbContextOptions<SocialSyncDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SocialSyncDbContext).Assembly);
            
            modelBuilder.Entity<PostLike>()
                .HasKey(e => new { e.UserId, e.PostId });
            
            modelBuilder.Entity<PostTag>()
                .HasKey(e => new { e.PostId, e.TagId });
            
         
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.DateModified = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                }



            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Follow> Follows { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        
        public DbSet<Notification> Notifications { get; set; }
    }
}
