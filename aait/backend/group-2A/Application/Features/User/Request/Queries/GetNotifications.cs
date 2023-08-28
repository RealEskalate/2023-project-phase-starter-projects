using Application.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class GetNotifications : IRequest<BaseCommandResponse<List<Notification>>?>{
    public required int Id{ get; set; }
    
}