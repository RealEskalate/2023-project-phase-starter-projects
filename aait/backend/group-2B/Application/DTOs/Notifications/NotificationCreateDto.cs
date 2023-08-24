namespace SocialSync.Application.DTOs.Notifications;

public class NotificationCreateDto:INotificationDto
{
    public int SenderId { get; set; }

    public NotificationType NotificationType{get; set;}

    public int RecepientId { get; set; }
}
