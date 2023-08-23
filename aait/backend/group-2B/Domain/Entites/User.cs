using SocialSync.Domain.Common;

namespace SocialSync.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public virtual ICollection<User> Followers { get; set; } = null!;
    public virtual ICollection<User> Followings { get; set; } = null!;
    public virtual ICollection<Post> Posts { get; set; } = null!;
    public virtual ICollection<Interaction> Interactions { get; set; } = null!;
    
    public virtual ICollection<Notification> NotificationsReceived  { get; set; } = null!;
    public virtual ICollection<Notification> NotificationsSent  { get; set; } = null!;
}
