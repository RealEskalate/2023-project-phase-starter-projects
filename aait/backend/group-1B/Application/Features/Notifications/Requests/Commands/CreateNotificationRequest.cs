using Application.DTOs.Notifications;
using MediatR;

namespace Application.Features.Notifications.Requests.Commands;

public class CreateNotificationRequest : IRequest<GetNotificationDto>
{
    public GetNotificationDto notification { get; set; }
}