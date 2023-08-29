namespace SocialSync.Application.DTOs.Notifications;

public enum NotificationType
{
    Like,
    Follow
}
public interface INotificationDto
{
    public int SenderId { get; set; }

    public string NotificationType{get; set;}

    public int RecepientId { get; set; }
}
