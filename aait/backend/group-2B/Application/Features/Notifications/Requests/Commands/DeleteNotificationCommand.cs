using MediatR;

namespace SocialSync.Application.Features.Notifications.Requests.Commands;

public class DeleteNotificationCommand : IRequest<Unit>
{
    public int NotificationId {get; set; }
}
