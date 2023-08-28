using Application.Responses;
using MediatR;

namespace Application.Features.Post.Request.Commands;

public class DeletePostCommand : IRequest<BaseCommandResponse<Unit>>
{
    public required int Id{ get; set; }
    
}