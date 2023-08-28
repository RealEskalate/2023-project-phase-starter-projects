using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.Notifications;


namespace SocialSyncApplication.Features.Notifications.Requests.Commands;

public class CreateNotificationCommand : IRequest<CommonResponse<int>>
{
    public NotificationCreateDto NotificationCreateDto {get; set;} = null!;
}
