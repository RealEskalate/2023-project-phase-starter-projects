using Application.DTOs.Notifications;
using Application.DTOs.Notifications.Validators;
using MediatR;

namespace Application.Features.Notifications.Requests.Queries;

public class GetAllNotificationsRequest : IRequest<List<GetNotificationDto>>
{
    public int UserId { get; set; }
}