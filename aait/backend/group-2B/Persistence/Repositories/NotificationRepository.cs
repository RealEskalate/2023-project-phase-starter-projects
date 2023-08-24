using Microsoft.EntityFrameworkCore;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;


namespace SocialSync.Persistence.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly SocialSyncDbContext _dbContext;
        public NotificationRepository(SocialSyncDbContext dbContext)
            : base(dbContext) { 
                _dbContext = dbContext;
            }

        public async Task<List<Notification>> GetAll(int userId)
        {
            return await _dbContext.Set<Notification>()
                .Where(n => n.RecepientId == userId)
                .ToListAsync();
        }
    }
}
