

using Microsoft.EntityFrameworkCore;
using SocialSync.Domain;

namespace SocialSync.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }


    }
}
