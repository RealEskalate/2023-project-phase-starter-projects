using SocialSync.Application.DTOs.Common;


namespace SocialSync.Application.DTOs.Notifications;

public class NotificationDto : BaseDto, INotificationDto
{
    public int SenderId { get; set; }
    public int RecepientId { get; set; }

    public NotificationType NotificationType{get; set;}


    public DateTime CreatedAt;
    public DateTime LastModified;

}
