namespace Domain.Entities
{
    public class Post
    {
   
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int LikeCount { get; set; } 
        public int CommentCount { get; set; }
        public List<Tag>? Tags { get; set; }
        
        // Navigation Property
        public virtual ICollection<User> User{ get; set; }
        public virtual ICollection<Comment>? Comments{ get; set; } = new HashSet<Comment>();
        public virtual ICollection<Like>? Likes{ get; set; } = new HashSet<Like>();
    }
}