using MediatR;
using SocialMediaApp.Application.DTOs.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Notifications.Request.Queries;

public class GetNotificationsRequest : IRequest<List<NotificationDto>>
{
    public Guid UserId { get; set; }
}
