using Application.Contracts;
using Application.Features.CommentFeatures.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Commands
{
    public class CommentDeleteCommandHandler : IRequestHandler<CommentDeleteCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;

        public CommentDeleteCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(CommentDeleteCommand request, CancellationToken cancellationToken)
        {

            await _commentRepository.DeleteCommentAsync(request.Id);

            return Unit.Value;
        }
    }
}
