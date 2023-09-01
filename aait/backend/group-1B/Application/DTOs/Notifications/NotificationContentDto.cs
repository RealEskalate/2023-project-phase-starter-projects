using Application.DTOs.Common;
using Domain.Entities;

namespace Application.DTOs.Notifications;

public class NotificationContentDto : BaseDto
{
    public int UserId { get; set; }
    public NotificationType NotificationType;
    public string Message { get; set; } = string.Empty;
    public bool Seen { get; set; }
}