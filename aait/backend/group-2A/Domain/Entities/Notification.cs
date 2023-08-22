
namespace Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }

        //The User That Should Get Notified
        public required string UserId { get; set; }
        public int PostId { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
