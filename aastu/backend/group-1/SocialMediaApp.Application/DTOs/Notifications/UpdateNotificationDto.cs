using SocialMediaApp.Application.DTOs.Common;


namespace SocialMediaApp.Application.DTOs.Notifications;

public class UpdateNotificationDto : BaseDto
{
    public string Content { get; set; } = "";
}

