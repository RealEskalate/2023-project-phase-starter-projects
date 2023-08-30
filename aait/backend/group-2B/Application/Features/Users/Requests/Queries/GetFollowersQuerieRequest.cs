
using Application.DTOs.Common;
using MediatR;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Requests.Queries
;
public class GetFollowersQuerieRequest : IRequest<CommonResponse<List<UserDto>>>
{
    public int Id { get; set; }
}
