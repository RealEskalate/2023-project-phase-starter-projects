using Application.DTOs.Notifications;
using MediatR;

namespace Application.Features.Notifications.Requests.Commands;

public class MarkNotificationAsSeenRequest : IRequest<Unit>
{
    public UpdateNotificationDto UpdateDto { get; set; }
}