using SocialSync.Domain.Common;

namespace SocialSync.Domain.Entities;

public class Post : BaseEntity
{
    public string Content { get; set; } = null!;
    public int UserId { get; set; }
    public int LikeCount{get; set;}

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Interaction> Interactions { get; set; } = null!;
    public virtual ICollection<Notification>? Notifications {get; set;}
}
