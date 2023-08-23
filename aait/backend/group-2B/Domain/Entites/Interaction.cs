using SocialSync.Domain.Common;

namespace SocialSync.Domain.Entities;

public enum InteractionType
{
    Like,
    Comment
}

public class Interaction : BaseEntity
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public InteractionType Type { get; set; }
    public string? Body { get; set; }

    public virtual Post Post { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
