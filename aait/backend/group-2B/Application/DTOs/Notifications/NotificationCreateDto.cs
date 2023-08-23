namespace SocialSync.Application.DTOs.Notifications;

public class NotificationCreateDto:INotificationDto
{
    public int FollowerUserId { get; set; }
    public int FollowedUserId { get; set; }
}
