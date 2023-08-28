using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Configurations.Entities
{
    public class CommentReactionConfiguration : IEntityTypeConfiguration<CommentReaction>
    {
        public void Configure(EntityTypeBuilder<CommentReaction> builder)
        {
            builder.HasOne(p => p.Comment)             
               .WithMany(a => a.CommentReactions)          
               .HasForeignKey(p => p.CommentId)   
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
