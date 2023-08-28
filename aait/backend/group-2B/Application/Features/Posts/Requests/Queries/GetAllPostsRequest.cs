using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Queries;

public class GetAllPostsRequest : IRequest<CommonResponse<List<PostDto>>>
{

}