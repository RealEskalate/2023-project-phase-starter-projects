
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            
        }
    }
}