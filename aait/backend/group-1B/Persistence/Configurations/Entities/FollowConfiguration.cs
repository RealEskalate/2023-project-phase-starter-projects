using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Entities
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {

            builder.HasKey(f => new { f.FollowerId, f.FolloweeId });

            builder.HasOne(u => u.Followee)
                .WithMany(u => u.Followers)
                .HasForeignKey(u => u.FolloweeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Follower)
               .WithMany(u => u.Followees)
               .HasForeignKey(u => u.FollowerId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
