using Application.DTO.FollowDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FollowFeatures.Request.Command
{
    public class DeleteFollowCommand : IRequest<Unit>
    {
        public required FollowDto unfollow { get; set; }
    }
}
