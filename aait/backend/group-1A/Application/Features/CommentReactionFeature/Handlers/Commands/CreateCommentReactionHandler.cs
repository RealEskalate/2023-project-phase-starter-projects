using Application.Contracts;
using Application.Features.CommentReactionFeatures.Requests.Commands;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentReactionFeatures.Handlers.Commands
{
    public class CommentReactionCreateCommandHandler : IRequestHandler<CommentReactionCreateCommand, Unit>
    {
        private readonly ICommentReactionRepository _commentReactionRepository;

        public CommentReactionCreateCommandHandler(ICommentReactionRepository commentReactionRepository)
        {
            _commentReactionRepository = commentReactionRepository;
        }

        public async Task<Unit> Handle(CommentReactionCreateCommand request, CancellationToken cancellationToken)
        {
            // Implement your logic to create a comment reaction
            var commentReaction = new CommentReaction
            {
                CommentId = request.CommentId,
                UserId = request.UserId,
                Like = request.Like,
                Dislike = request.Dislike
            };

            await _commentReactionRepository.AddCommentReactionAsync(commentReaction);

            return Unit.Value;
        }
    }
}
