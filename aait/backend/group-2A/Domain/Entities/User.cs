

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Bio { get; set; } = "";
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
        public int PostCount { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Navigation Property
        public ICollection<Post> Posts{ get; set; } = new HashSet<Post>();
        public ICollection<Follow> Following{ get; set; } = new HashSet<Follow>();
        public ICollection<Follow> Follower{ get; set; } = new HashSet<Follow>();

    }
}
