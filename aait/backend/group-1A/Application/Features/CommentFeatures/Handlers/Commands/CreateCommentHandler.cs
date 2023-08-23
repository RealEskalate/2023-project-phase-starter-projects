using Application.Features.CommentFeatures.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Commands
{
    public class CommentCreateCommandHandler : IRequestHandler<CommentCreateCommand, int>
    {
        public async Task<int> Handle(CommentCreateCommand request, CancellationToken cancellationToken)
        {
            // Implement your logic to create a comment and return the comment ID
            // Example: var commentId = await commentRepository.CreateCommentAsync(request);
            // return commentId;
            return 0;
        }
    }
}
