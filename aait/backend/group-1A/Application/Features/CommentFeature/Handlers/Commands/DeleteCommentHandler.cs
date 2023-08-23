using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Commands
{
    public class CommentDeleteCommandHandler : IRequestHandler<CommentDeleteCommand>
    {
        public async Task<Unit> Handle(CommentDeleteCommand request, CancellationToken cancellationToken)
        {
            // Implement your logic to delete a comment
            // Example: await commentRepository.DeleteCommentAsync(request.Id);
            return Unit.Value;
        }
    }
}
