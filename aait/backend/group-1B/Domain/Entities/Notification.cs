using Domain.Common;

namespace Domain.Entities;

public abstract class Notification : BaseEntity
{
    protected Notification(User user)
    {
        User = user;
    }

    public string Message { get; set; } = "";

    public bool Seen { get; set; } = false;

    public enum NotificationType
    {
        Like,
        Comment,
        Follow
    }

    public int UserId { get; set; }

    // Navigation property to the User entity
    public User User { get; set; }
}