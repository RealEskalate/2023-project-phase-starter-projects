using Application.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class GetNotifications : IRequest<BaseCommandResponse<List<Notification>>?>{
    public required int UserId{ get; set; }
    public int PageNumber{ get; set; } = 0;
    public int PageSize{ get; set; } = 10;
    
}