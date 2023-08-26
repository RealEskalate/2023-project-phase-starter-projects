using Application.DTO.Post;
using Application.Responses;
using MediatR;

namespace Application.Features.Post.Request.Commands;

public class CreatePostCommand : IRequest<BaseCommandResponse<int>>
{
    public required CreatePostDto CreatePost { get; set; }
    
}