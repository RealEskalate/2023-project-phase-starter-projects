using Application.DTO.CommentReactionDTOS.DTO;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.CommentReactionFeatures.Requests.Queries
{
    public class GetAllCommentReactionsQuery : IRequest<List<CommentReactionDTO>>
    {

    }
}
