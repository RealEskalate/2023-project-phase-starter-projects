using Domain.Common;
using Domain.Entites;
using SocialSync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public virtual ICollection<PostReaction> PostReactions { get; set; } = new HashSet<PostReaction>();

        public virtual ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();

    }
}

