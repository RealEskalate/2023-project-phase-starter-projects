using Application.Contracts.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class NotificationRepository : INotificationRepository{
    private readonly SocialSyncDbContext _dbContext;


    public NotificationRepository(SocialSyncDbContext context){
        _dbContext = context;
    }


    public async Task AddNotification(Notification notify){
        await _dbContext.Notifications.AddAsync(notify);
    }

    public async Task<List<Notification>> GetNotifications(int UserId, int pageNumber = 0, int pageSize = 10)
    {
        return await _dbContext.Notifications
            .Where(notify => notify.UserId == UserId)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task MarkAsRead(int Id)
    {
        var notification = await GetNotification(Id);
        if (notification == null)
            return;

        notification.IsRead = true;
    }

    public async Task<Notification> GetNotification(int notificationId)
    {
        return await _dbContext.Notifications.FindAsync(notificationId);
    }
    
}