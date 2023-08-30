using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Feed.Requests.Queries;

public class GetFeedsByUserIdRequest : IRequest<CommonResponse<List<PostDto>>>
{
    public int UserID;
}
