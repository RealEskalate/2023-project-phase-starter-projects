using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SocialMediaApp.Application.Features.Follows.Request.Commands
{
    public class DeleteFollowCommandRequest:IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}