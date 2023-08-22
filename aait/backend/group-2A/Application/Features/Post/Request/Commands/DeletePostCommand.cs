using MediatR;

namespace Application.Features.Post.Request.Commands;

public class DeletePostCommand : IRequest<Unit>
{
    public required int Id{ get; set; }
    
}