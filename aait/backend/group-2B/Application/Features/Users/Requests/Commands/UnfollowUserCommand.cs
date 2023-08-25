using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Common;
using MediatR;

namespace Application.Features.Users.Requests.Commands
{
    public class UnFollowUserCommand : IRequest<Unit>
    {
        public FollowUnFollowDto UnfollowunFollowDto {get;set;} 


    }
}