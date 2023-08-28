

using Domain.Common;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string Bio { get; set; } = "";
        public int FollowerCount{ get; set; } = 0;
        public int FolloweeCount{ get; set; } = 0;
        public int PostCount{ get; set; } = 0;
        public DateTime? UpdatedAt { get; set; }
        
        // Navigation Property
        public ICollection<Post> Posts{ get; set; } = new HashSet<Post>();
        public ICollection<Comment> Comments{ get; set; } = new HashSet<Comment>();
        public ICollection<Like> Likes{ get; set; } = new HashSet<Like>();
        public ICollection<Follow> Followee{ get; set; } = new HashSet<Follow>();
        public ICollection<Follow> Follower{ get; set; } = new HashSet<Follow>();
        public ICollection<Notification> Notifications{ get; set; } = new HashSet<Notification>();

    }
}
