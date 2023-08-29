using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Notifications;

public interface INotificationDto
{
    public string Content { get; set; }
    public Guid UserId { get; set; }
}
