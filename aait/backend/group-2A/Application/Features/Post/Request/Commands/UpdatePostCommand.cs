using Application.DTO.Post;
using Application.Responses;
using MediatR;

namespace Application.Features.Post.Request.Commands;

public class UpdatePostCommand : IRequest<BaseCommandResponse<Unit>>
{
    public required UpdatePostDto UpdatedPost{ get; set; }
}