using Application.Contracts;
using Application.Features.CommentReactionFeatures.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentReactionFeatures.Handlers.Commands
{
    public class CommentReactionDeleteCommandHandler : IRequestHandler<CommentReactionDeleteCommand, Unit>
    {
        private readonly ICommentReactionRepository _commentReactionRepository;

        public CommentReactionDeleteCommandHandler(ICommentReactionRepository commentReactionRepository)
        {
            _commentReactionRepository = commentReactionRepository;
        }

        public async Task<Unit> Handle(CommentReactionDeleteCommand request, CancellationToken cancellationToken)
        {
            // Implement your logic to delete a comment reaction
            await _commentReactionRepository.DeleteCommentReactionAsync(request.Id);

            return Unit.Value;
        }
    }
}
