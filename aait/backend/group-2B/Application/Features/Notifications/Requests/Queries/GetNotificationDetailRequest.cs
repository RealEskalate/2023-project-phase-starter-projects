using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.Notifications;

namespace SocialSync.Application.Features.Notifications.Requests.Queries;

public class GetNotificationDetailRequest : IRequest<CommonResponse<NotificationDto>>
{
    public int Id {get; set; }
}