using MediatR;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Responses;

namespace SocialSync.Application.Features.Posts.Requests.Commands;

public class UpdatePostCommand: IRequest<BaseCommandResponse>{
    public UpdatePostDto UpdatePostDto{get; set;}
    public UpdatePostCommand(UpdatePostDto newPostDto)
    {
        UpdatePostDto = newPostDto;
    }
}