using MediatR;

namespace Application.Features.Like.Request.Commands;

public class DeleteLikeCommand : IRequest<uint>
{
    public int Id{ get; set; }
    
}