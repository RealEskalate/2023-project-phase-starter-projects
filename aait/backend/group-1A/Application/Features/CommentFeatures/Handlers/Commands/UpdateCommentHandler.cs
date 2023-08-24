using Application.Contracts;
using Application.Features.CommentFeatures.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Commands
{
    public class CommentUpdateCommandHandler : IRequestHandler<CommentUpdateCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;

        public CommentUpdateCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(CommentUpdateCommand request, CancellationToken cancellationToken)
        {
            // Implement your logic to update a comment
            await _commentRepository.UpdateCommentAsync(request);

            return Unit.Value;
        }
    }
}
