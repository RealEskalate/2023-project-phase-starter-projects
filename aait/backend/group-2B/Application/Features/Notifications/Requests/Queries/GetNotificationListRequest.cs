using MediatR;
using SocialSync.Application.DTOs.Notifications;


namespace SocialSync.Application.Features.Notifications.Requests.Queries;

public class GetNotificationListRequest : IRequest<List<NotificationListDto>>
{
    public int UserId {get; set; }
}
