using MediatR;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Common.Responses;

namespace SocialSync.Application.Features.Posts.Requests.Commands;

public class CreatePostCommand : IRequest<CommonResponse<int>>
{
    public CreatePostDto CreatePostDto { get; set; } = null!;

}
