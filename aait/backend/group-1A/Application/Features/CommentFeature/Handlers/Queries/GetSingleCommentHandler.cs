using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Queries
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, CommentDTO>
    {
        public async Task<CommentDTO> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            // Implement  logic to retrieve a single comment by ID
            // var comment = await commentRepository.GetCommentByIdAsync(request.CommentId);
            // return comment;
            return null;
        }
    }
}
