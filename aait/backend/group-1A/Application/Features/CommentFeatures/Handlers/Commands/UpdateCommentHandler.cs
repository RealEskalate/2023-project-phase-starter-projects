using Application.Features.CommentFeatures.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Commands
{
    public class CommentUpdateCommandHandler : IRequestHandler<CommentUpdateCommand, Unit>
    {
        public async Task<Unit> Handle(CommentUpdateCommand request, CancellationToken cancellationToken)
        {
            // Implement your logic to update a comment
            // Example: await commentRepository.UpdateCommentAsync(request);
            return Unit.Value;
        }
    }
}
