using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Queries;

public class GetPostsByTagsRequest : IRequest<CommonResponse<List<PostDto>>>
{

    public List<string> Tags { get; set; } = null!;
}