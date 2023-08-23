using MediatR;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Responses;

namespace SocialSync.Application.Features.Posts.Requests.Commands;

public class CreatePostCommand : IRequest<BaseCommandResponse>
{
    public CreatePostDto CreatePostDto { get; set; }
    public CreatePostCommand(CreatePostDto newPostDto)
    {
        CreatePostDto = newPostDto;
    }
}
