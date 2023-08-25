using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.Common;
using Application.Response;
using MediatR;

namespace Application.Features.CommentReactionFeature.Requests.Queries
{
    public class GetCommentsDislikeQuery : IRequest<BaseResponse<List<ReactionResponseDTO>>>
    {
        public int CommentId { get; set; }
    }
}