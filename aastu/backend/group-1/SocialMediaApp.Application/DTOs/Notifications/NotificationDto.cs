using SocialMediaApp.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Notifications;

public class NotificationDto : BaseDto, INotificationDto
{
    public string Content { get; set; } = "";
    public Guid UserId { get; set; }
    public bool IsRead { get; set; }
}
