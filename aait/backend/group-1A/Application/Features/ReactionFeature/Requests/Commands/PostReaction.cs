using Application.DTO.Common;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Requests.Commands
{
    public class PostReactionCommand : IRequest<BaseResponse<int>>
    {
        public int UserId { get; set; }
        public ReactionDTO ReactionData { get; set; }
    }
}
