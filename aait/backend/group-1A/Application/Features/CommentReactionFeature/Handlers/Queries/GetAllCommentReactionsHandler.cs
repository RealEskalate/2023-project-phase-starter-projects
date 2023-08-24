using Application.Contracts;
using Application.DTO.CommentReactionDTOS.DTO;
using Application.Features.CommentReactionFeatures.Requests.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentReactionFeatures.Handlers.Queries
{
    public class GetAllCommentReactionsQueryHandler : IRequestHandler<GetAllCommentReactionsQuery, List<CommentReactionDTO>>
    {
        private readonly ICommentReactionRepository _commentReactionRepository;

        public GetAllCommentReactionsQueryHandler(ICommentReactionRepository commentReactionRepository)
        {
            _commentReactionRepository = commentReactionRepository;
        }

        public async Task<List<CommentReactionDTO>> Handle(GetAllCommentReactionsQuery request, CancellationToken cancellationToken)
        {

            var commentReactions = await _commentReactionRepository.GetAllCommentReactionsAsync();



            return commentReactions;
        }
    }
}
