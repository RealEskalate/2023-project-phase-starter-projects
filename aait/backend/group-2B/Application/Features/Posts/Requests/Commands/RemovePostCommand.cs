using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Commands;

public class RemovePostCommand : IRequest<CommonResponse<Unit>>
{
    public RemovePostDto RemovePostDto;
    public RemovePostCommand(RemovePostDto postDto)
    {
        RemovePostDto = postDto;
    }
}
