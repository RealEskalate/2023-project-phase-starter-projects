using MediatR;
using SocialSync.Application.DTOs.Notifications;

namespace SocialSync.Application.Features.Notifications.Requests.Queries;

public class GetNotificationDetailRequest : IRequest<NotificationDto>
{
    public int Id {get; set; }
}