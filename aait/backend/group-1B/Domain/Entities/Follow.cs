using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Follow
    {

        public int FollowerId { get; set; }

        public int FolloweeId { get; set; }

        public virtual User Follower { get; set; }

        public virtual User Followee { get; set; }
    }
}
