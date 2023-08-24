using Application.DTOs.Common;

namespace Application.DTOs.Notifications;

public class GetNotificationDto : BaseDto
{
    public int UserId { get; set; }
    public string Message { get; set; } = "";
}