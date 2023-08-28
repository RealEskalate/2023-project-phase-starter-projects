using Application.Contracts.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class NotificationRepository : INotificationRepository{
    private readonly SocialSyncDbContext _dbContext;


    public NotificationRepository(SocialSyncDbContext context){
        _dbContext = context;
    }


    public async Task AddNotification(Notification notify){
        await _dbContext.Notifications.AddAsync(notify);
    }

    public async Task<List<Notification>> GetNotifications(int Id)
    {
        return await _dbContext.Notifications
            .Where(notify => notify.UserId == Id)
            .ToListAsync();
    }

}