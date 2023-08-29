using MediatR;
using SocialMediaApp.Application.DTOs.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Notifications.Request.Queries;

public class GetNotificationDetailsRequest : IRequest<NotificationDto>
{
    public Guid UserId { get; set; }
    public Guid NotificationId { get; set; }
}
