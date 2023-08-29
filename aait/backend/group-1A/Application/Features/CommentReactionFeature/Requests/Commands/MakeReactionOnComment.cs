using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.Common;
using Application.Response;
using MediatR;

namespace Application.Features.CommentReactionFeature.Requests.Commands
{
    public class MakeReactionOnComment : IRequest<BaseResponse<int>>
    {
        public int UserId { get; set; }
        public ReactionDTO ReactionData { get; set; }
    }
}