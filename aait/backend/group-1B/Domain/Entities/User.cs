using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int NumFollowers { get; set; } 

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Bio { get; set; }

        public virtual IEnumerable<Follow> Followers { get; set; }

        public virtual IEnumerable<Follow> Followees { get; set; }
        
        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        
        public virtual IEnumerable<PostLike> PostLikes { get; set; }

        public virtual IEnumerable<Notification> Notifications { get; set; }
    }
}
