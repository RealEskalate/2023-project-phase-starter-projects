using Domain.Common;

namespace Domain.Entities;

public class Comment : BaseEntity
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; } = string.Empty;
    
    public virtual User User { get; set; }
    public virtual Post Post { get; set; }
}