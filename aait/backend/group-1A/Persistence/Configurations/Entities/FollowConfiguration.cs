using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations.Entities
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Follow> builder)
        {
            builder                                        
                .HasKey(k => new { k.FollowerId, k.FolloweeId });

            builder                                        
                .HasOne(u => u.Followee)
                .WithMany( u => u.Follower)
                .HasForeignKey(u => u.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder                                        
                .HasOne(u => u.Follower)
                .WithMany( u => u.Followee)
                .HasForeignKey(u => u.FolloweeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}