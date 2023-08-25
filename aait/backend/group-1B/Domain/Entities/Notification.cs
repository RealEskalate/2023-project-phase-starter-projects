using Domain.Common;

namespace Domain.Entities;
public enum NotificationType
{
    Like,
    Comment,
    Follow
}

public class Notification : BaseEntity
{
    public string Message { get; set; } = "";

    public bool Seen { get; set; } = false;

    public NotificationType NotificationType { get; set; }
    public int UserId { get; set; }

    // Navigation property to the User entity
    public User User { get; set; }
}