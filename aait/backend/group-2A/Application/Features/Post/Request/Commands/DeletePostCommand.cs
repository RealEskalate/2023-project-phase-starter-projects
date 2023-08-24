using Application.Responses;
using MediatR;

namespace Application.Features.Post.Request.Commands;

public class DeletePostCommand : IRequest<BaseCommandResponse>
{
    public required int Id{ get; set; }
    
}