
using System.Linq.Expressions;
using Application.Contracts;
using Domain.Entites;

namespace Persistence.Repositories.NotificationRepository
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

        

        public async Task<bool> MarkAllAsRead(Expression<Func<Notification, bool>> predicate)
        {
            var allUnread = await GetAll(predicate);
            
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
    }
}