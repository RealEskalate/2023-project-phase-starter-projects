using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialSync.Domain.Entities;

namespace Domain.Entites
{
    public class Follow
    {
        public int FollowerId { get; set; }
        public int FolloweeId { get; set; }   
        public virtual User Follower { get; set; }
        public virtual User Followee { get; set; }
    }
}