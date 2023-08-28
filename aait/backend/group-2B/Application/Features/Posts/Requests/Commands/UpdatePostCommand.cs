using MediatR;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Common.Responses;

namespace SocialSync.Application.Features.Posts.Requests.Commands;

public class UpdatePostCommand : IRequest<CommonResponse<Unit>>
{
    public UpdatePostDto UpdatePostDto { get; set; } = null!;

}