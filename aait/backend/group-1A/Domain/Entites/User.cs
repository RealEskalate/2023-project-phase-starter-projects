using Domain.Entites;
using Domain.Entities;

namespace SocialSync.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        
        public virtual ICollection<Follow>? Follower { get; set; }

        public virtual ICollection<Follow>? Followee { get; set; }

    }
}