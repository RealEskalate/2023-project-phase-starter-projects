using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(SocialSyncDbContext context) : base(context)
    {
    }

    public async Task<List<Notification>> GetByUserId(int userId)
    {
        var notifications = await _context.Notifications.Where(notif => notif.UserId == userId).ToListAsync();
        return notifications;
    }

    public async Task MarkAsSeen(int id)
    {
        var notification = await Get(id);
        if (notification == null)
            return;

        notification.Seen = true;
    }
}