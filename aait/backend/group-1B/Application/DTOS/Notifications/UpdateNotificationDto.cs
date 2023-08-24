using Application.DTOs.Common;

namespace Application.DTOs.Notifications;

public class UpdateNotificationDto : BaseDto
{ 
    public int UserId { get; set; }
}