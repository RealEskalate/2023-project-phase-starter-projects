using SocialSync.Application.DTOs.Common;


namespace SocialSync.Application.DTOs.Notifications;

public class NotificationDto : BaseDto, INotificationDto
{
    public int SenderId { get; set; }
    public int RecepientId { get; set; }

    public string NotificationType{get; set;} = null!;
    public int? PostId {get; set;}
    public DateTime CreatedAt;
    public DateTime LastModified;

}
