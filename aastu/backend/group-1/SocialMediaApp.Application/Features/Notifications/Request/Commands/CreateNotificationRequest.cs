using MediatR;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Notifications.Request.Commands;

public class CreateNotificationRequest : IRequest<BaseResponseClass>
{
    public CreateNotificationDto CreateNotificationDto { get; set; } 
}
