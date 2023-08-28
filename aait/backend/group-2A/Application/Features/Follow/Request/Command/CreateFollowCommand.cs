using Application.DTO.FollowDTO;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FollowFeatures.Request.Command
{
    public class CreateFollowCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public required FollowDto follow { get; set; }
    }
}
