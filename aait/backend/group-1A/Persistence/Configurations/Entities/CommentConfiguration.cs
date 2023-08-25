using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Persistence.Configurations.Entities
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(p => p.post)             
               .WithMany(a => a.Comments)          
               .HasForeignKey(p => p.PostId)   
               .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
