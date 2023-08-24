using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.Configurations.Entities
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            
        }
    }
}
            //builder.Property(e => e.Id)
            //      .HasDefaultValueSql("nextval('Id')");
                  //.ValueGeneratedOnAdd();
