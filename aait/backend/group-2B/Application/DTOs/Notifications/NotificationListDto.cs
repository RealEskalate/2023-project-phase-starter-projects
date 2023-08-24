
namespace SocialSync.Application.DTOs.Notifications;
public class NotificationListDto : INotificationDto
{
    public int SenderId { get; set; }
    public int RecepientId { get; set; }
    public NotificationType NotificationType{get; set;}

}
