namespace SocialSync.Application.DTOs.Notifications;

public class NotificationCreateDto:INotificationDto
{
    public int SenderId { get; set; }

    public string NotificationType{get; set;} = null!;

    public int RecepientId { get; set; }
    public int? PostId {get; set;}
}
