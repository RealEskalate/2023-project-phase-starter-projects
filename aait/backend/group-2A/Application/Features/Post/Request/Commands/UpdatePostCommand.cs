using Application.DTO.Post;
using MediatR;

namespace Application.Features.Post.Request.Commands;

public class UpdatePostCommand : IRequest<Unit>
{
    public required UpdatePostDto UpdatedPost{ get; set; }
}