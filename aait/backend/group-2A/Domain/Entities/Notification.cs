
namespace Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        //The User That Should Get Notified
        public required int UserId { get; set; }
        public required int NotifierId{ get; set; }
        public required string Message { get; set; }
        // public bool IsRead{ get; set; } = false;
        public DateTime CreatedAt { get; set; }
        
        public virtual User User{ get; set; }
        public virtual User Notifier{ get; set; }
    }

}
