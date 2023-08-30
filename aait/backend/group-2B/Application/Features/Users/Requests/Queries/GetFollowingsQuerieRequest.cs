using Application.DTOs.Common;
using MediatR;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Requests.Queries;

public class GetFollowingsQuerieRequest : IRequest<CommonResponse<List<UserDto>>>
{
    public int Id { get; set; }

}
