using MediatR;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Commands;

public class CreatePostCommand : IRequest<GeneralPostDto>
{
    public CreatePostDto CreatePostDto { get; set; }
    public CreatePostCommand(CreatePostDto newPostDto)
    {
        CreatePostDto = newPostDto;
    }
}
