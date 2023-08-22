
namespace Domain.Entities
{
    public class Follow
    {
        //User That Followed A Certain User
        public int FollowerId { get; set; }
        //User That Got Followed
        public int FollowedId { get; set; }
        
        //Navigation Property
        public virtual User? Follower{ get; set; }
        public virtual User? Following{ get; set; }
    }
}