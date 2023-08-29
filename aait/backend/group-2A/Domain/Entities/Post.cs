using Domain.Common;

namespace Domain.Entities
{
    public class Post : BaseEntity
    {
   
        public required int UserId { get; set; }
        public required string Content { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int LikeCount{ get; set; } = 0;
        public int CommentCount{ get; set; } = 0;
        public List<string> Tags{ get; set; } = new List<string>();
        
        // Navigation Property
        public virtual User? User{ get; set; }
        public virtual ICollection<Comment>? Comments{ get; set; } = new HashSet<Comment>();
        public virtual ICollection<Like>? Likes{ get; set; } = new HashSet<Like>();
    }
}