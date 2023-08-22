using Application.DTO.Post;
using MediatR;

namespace Application.Features.Post.Request.Commands;

public class CreatePostCommand : IRequest<int>
{
    public required CreatePostDto CreatePost { get; set; }
    
}