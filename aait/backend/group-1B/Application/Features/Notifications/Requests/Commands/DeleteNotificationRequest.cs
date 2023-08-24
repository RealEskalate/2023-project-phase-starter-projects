using Application.DTOs.Notifications;
using MediatR;

namespace Application.Features.Notifications.Requests.Commands;

public class DeleteNotificationRequest : IRequest<Unit>
{
    public UpdateNotificationDto DeleteDto { get; set; }
}