using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.Authentication;

namespace Application.Features.Users.Requests.Queries;

public class GetFollowersQuerieRequest : IRequest<CommonResponse<List<UserDto>>>
{
    public int Id { get; set; }
}
