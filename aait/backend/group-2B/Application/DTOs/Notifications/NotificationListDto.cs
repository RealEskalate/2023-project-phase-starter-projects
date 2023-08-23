
namespace SocialSync.Application.DTOs.Notifications;
public class NotificationListDto : INotificationDto
{
    public int FollowerUserId { get; set; }
    public int FollowedUserId { get; set; }
}
