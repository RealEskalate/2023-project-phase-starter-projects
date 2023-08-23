using Application.DTO.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Requests.Commands
{
    public class PostReactionCommand : IRequest<CommonResponseDTO>
    {
        public int UserId { get; set; }
        public ReactionDTO ReactionData { get; set; }
    }
}
