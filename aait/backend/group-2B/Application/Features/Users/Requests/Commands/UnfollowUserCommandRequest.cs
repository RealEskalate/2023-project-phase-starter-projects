using Application.DTOs.Common;
using MediatR;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Requests.Commands;

public class UnFollowUserCommandRequest : IRequest<CommonResponse<int>>
{
    public required FollowUnFollowDto UnfollowDto { get; set; }
}
