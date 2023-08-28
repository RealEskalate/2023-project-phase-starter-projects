using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Queries;

public class GetPostsByUserIdRequest : IRequest<CommonResponse<List<PostDto>>>
{
    public int UserId { get; set; }
}