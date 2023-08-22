using SocialSync.Domain.Common;

namespace SocialSync.Domain.Entities;

public class Notification : BaseAuditableEntity
{
    public string FollowerUserId { get; set; } = null!;
    public string FollowedUserId { get; set; } = null!;
}
