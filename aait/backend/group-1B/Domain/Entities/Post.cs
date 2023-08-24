using System.Collections;
using Domain.Common;

namespace Domain.Entities;

public class Post : BaseEntity
{
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int NumberOfLikes { get; set; }
    public int NumberOfComments { get; set; }
      
    public virtual  User User { get; set; }
    public virtual IEnumerable<Comment> Comments { get; set; }
    public virtual IEnumerable<PostLike> Likes { get; set; }
    public virtual IEnumerable<PostTag> PostTags { get; set; }
}