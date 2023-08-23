using MediatR;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Commands;

public class UpdatePostCommand: IRequest<Unit>{
    public UpdatePostDto UpdatePostDto{get; set;}
    public UpdatePostCommand(UpdatePostDto newPostDto)
    {
        UpdatePostDto = newPostDto;
    }
}