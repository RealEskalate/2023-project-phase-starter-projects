using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Persistence.Repositories;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    private readonly SocialMediaAppDbContext _dbContext;
    public NotificationRepository(SocialMediaAppDbContext dbContext):base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Notification> GetNotificationDetails(Guid userId, Guid id)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            var notification = await _dbContext.Notifications.FindAsync(id);
            
            if (notification != null && notification.UserId == user.Id)
            {
                notification.IsRead = true;
                await _dbContext.SaveChangesAsync();
                return notification;
            }
        }
        return null;
    }

    public async Task<List<Notification>> GetNotifications(Guid userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            var notifications = await  _dbContext.Notifications.Where(n=>n.UserId == userId && n.IsRead == false).OrderByDescending(n => n.CreatedDate).ToListAsync();
            return notifications;
        }
        return null;
    }
}
