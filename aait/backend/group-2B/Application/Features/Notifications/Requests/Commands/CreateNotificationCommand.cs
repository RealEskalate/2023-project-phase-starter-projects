using MediatR;
using SocialSync.Application.DTOs.Notifications;


namespace SocialSyncApplication.Features.Notifications.Requests.Commands;

public class CreateNotificationCommand : IRequest<int>
{
    public NotificationCreateDto NotificationCreateDto {get; set;} = null!;
}
