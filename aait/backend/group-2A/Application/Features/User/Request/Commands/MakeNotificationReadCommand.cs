using Application.DTO.NotificationDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.User.Request.Commands;

public class MakeNotificationReadCommand : IRequest<BaseCommandResponse<Unit?>>
{
    public UpdateNotificationDto UpdateDto { get; set; }
}