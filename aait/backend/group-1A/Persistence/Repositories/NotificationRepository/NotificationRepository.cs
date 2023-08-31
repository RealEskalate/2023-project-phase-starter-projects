
using System.Linq.Expressions;
using Application.Contracts;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly SocialMediaDbContext _dbContext;

        public NotificationRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Notification> GetSingle(int id)
        {
            var result = await _dbContext.Notifications.FindAsync(id);
            return result;
        }

        

        public async Task<bool> MarkAllAsRead(int userId)
        {
            var allUnread = await _dbContext.Notifications
                                .Where(x => x.IsRead == false && x.UserId == userId)
                                .ToListAsync();
            
            foreach(var notification in allUnread){
                notification.IsRead = true;
                await _dbContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> MarkAsRead(int id, int userId)
        {
            var notification = await GetSingle(id);
            notification.IsRead = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Exists(int id)
        {
            var result = await _dbContext.Notifications.FindAsync(id);
            return result != null;
        }

        public async Task<List<Notification>> GetAllUnread(int userId)
        {
            var allUnread = await _dbContext.Notifications
                                .Where(x => x.IsRead == false && x.UserId == userId)
                                .ToListAsync();
            
            return allUnread;
        }

        public async Task<List<Notification>> GetAll(int userId)
        {
            return await _dbContext.Notifications
                                .Where(x => x.UserId == userId)
                                .ToListAsync();
        }
    }
}