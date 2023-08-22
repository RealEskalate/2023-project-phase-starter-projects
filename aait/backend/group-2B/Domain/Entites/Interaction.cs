namespace SocialSync.Domain.Entities;

public enum InteractionType
{
    Like,
    Comment
}

public class Interaction
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public InteractionType Type { get; set; }
    public string? Body { get; set; }
}
