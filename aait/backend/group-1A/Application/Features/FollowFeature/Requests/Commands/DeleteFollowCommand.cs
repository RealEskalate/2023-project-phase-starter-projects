using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.DTO.Common;
using Application.DTO.FollowDTo;
using MediatR;

namespace Application.Features.FollowFeature.Requests.Commands
{
    public class DeleteFollowCommand : IRequest<CommonResponseDTO>
    {
        public FollowDTO? FollowDTO { get; set; }
    }
}