using SocialSync.Domain.Common;

namespace SocialSync.Domain.Entities;

public class Post : BaseAuditableEntity
{
    public string Content { get; set; } = null!;
    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Interaction> Interactions { get; set; } = null!;
}
