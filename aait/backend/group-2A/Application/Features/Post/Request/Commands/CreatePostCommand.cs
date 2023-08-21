using Application.DTO.Post;
using MediatR;

namespace Application.Features.Post.Request.Commands;

public class CreatePostCommand : IRequest<int>
{
    public CreatePostDto CreatePost { get; set; }
    
}