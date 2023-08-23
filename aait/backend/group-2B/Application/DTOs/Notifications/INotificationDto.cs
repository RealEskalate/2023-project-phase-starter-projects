namespace SocialSync.Application.DTOs.Notifications;

public interface INotificationDto
{
    public int FollowerUserId { get; set; }
    public int FollowedUserId { get; set; }
}
