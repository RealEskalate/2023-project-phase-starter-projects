using Application.DTOs.Notifications;
using MediatR;

namespace Application.Features.Notifications.Requests.Queries;

public class GetNotificationRequest : IRequest<NotificationContentDto>
{
    public int Id { get; set; }
}