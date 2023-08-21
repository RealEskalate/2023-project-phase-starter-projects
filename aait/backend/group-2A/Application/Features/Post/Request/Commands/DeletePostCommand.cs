using MediatR;

namespace Application.Features.Post.Request.Commands;

public class DeletePostCommand : IRequest<Unit>
{
    public int Id{ get; set; }
    
}