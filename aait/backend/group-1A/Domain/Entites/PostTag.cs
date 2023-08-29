using Domain.Entities;

namespace SocialSync.Domain.Entities;

public class PostTag{
    public int Id { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
    public int TagId { get; set; }
    public Tag Tag { get; set; } = null!;
}