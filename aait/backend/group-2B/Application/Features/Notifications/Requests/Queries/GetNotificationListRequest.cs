using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.Notifications;


namespace SocialSync.Application.Features.Notifications.Requests.Queries;

public class GetNotificationListRequest : IRequest<CommonResponse<List<NotificationListDto>>>
{
    public int UserId {get; set; }
}
