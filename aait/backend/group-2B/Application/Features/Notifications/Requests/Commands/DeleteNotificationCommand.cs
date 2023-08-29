using MediatR;
using SocialSync.Application.Common.Responses;

namespace SocialSync.Application.Features.Notifications.Requests.Commands;

public class DeleteNotificationCommand : IRequest<CommonResponse<Unit>>
{
    public int NotificationId {get; set; }
}
