
namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; } 
        public required string Content { get; set; }

        //The User That Commented
        public int UserId { get; set; }
        public int PostId { get; set; }
        
        public int CreatedAt{ get; set; }
        public int UpdatedAt{ get; set; }
        
        //Navigation Property
        public virtual User? User{ get; set; }
        public virtual Post? Post{ get; set; }
    }
}
