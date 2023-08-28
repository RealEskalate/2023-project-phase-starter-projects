using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Commands;

public class DeletePostCommand : IRequest<CommonResponse<Unit>>
{
    public DeletePostDto DeletePostDto = null!;

}
