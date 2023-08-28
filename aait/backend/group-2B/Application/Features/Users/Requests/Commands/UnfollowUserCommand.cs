
using Application.DTOs.Common;
using MediatR;

namespace Application.Features.Users.Requests.Commands
{
    public class UnFollowUserCommand : IRequest<Unit>
    {
        public required FollowUnFollowDto UnfollowunFollowDto {get;set;} 


    }
}