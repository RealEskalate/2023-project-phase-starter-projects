using SocialSync.Domain.Common;

namespace SocialSync.Domain.Entities;

public class Post : BaseAuditableEntity
{
    public string Content { get; set; } = null!;
    public int UserId { get; set; }
}
