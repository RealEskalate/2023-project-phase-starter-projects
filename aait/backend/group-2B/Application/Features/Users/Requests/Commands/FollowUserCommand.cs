
using Application.DTOs.Common;
using MediatR;

namespace Application.Features.Users.Requests.Commands
{
    public class FollowUserCommand : IRequest<Unit>{

        public required FollowUnFollowDto FollowUnfollowDto { get; set; }
    
    }
}