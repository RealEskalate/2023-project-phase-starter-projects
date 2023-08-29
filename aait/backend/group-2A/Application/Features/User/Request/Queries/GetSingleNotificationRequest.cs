using Application.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class GetSingleNotificationRequest : IRequest<BaseCommandResponse<Notification>?>
{
public required int Id{ get; set; }
    
}