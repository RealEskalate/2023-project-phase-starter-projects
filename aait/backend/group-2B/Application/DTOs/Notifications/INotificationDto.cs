namespace SocialSync.Application.DTOs.Notifications;


public interface INotificationDto
{
    public int SenderId { get; set; }

    public string NotificationType{get; set;}

    public int RecepientId { get; set; }
    public int? PostId {get; set;}
}
