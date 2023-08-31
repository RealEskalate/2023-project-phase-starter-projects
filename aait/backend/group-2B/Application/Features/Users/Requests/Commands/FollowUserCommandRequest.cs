using Application.DTOs.Common;
using MediatR;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Requests.Commands;

public class FollowUserCommandRequest : IRequest<CommonResponse<int>>
{
    public required FollowUnFollowDto FollowUnfollowDto { get; set; }
}
