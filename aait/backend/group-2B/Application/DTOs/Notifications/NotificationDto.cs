using SocialSync.Application.DTOs.Common;


namespace SocialSync.Application.DTOs.Notifications;

public class NotificationDto : BaseDto, INotificationDto
{
    public int FollowerUserId { get; set; }
    public int FollowedUserId { get; set; }

    public DateTime CreatedAt;
    public DateTime LastModified;

}
