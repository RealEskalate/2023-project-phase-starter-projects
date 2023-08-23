using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Queries
{
    public class GetCommentsForPostQueryHandler : IRequestHandler<GetCommentsForPostQuery, List<CommentDTO>>
    {
        public async Task<List<CommentDTO>> Handle(GetCommentsForPostQuery request, CancellationToken cancellationToken)
        {
            // Implement  logic to retrieve comments for a post
            //  var comments = await commentRepository.GetCommentsForPostAsync(request.PostId);
            // return comments;
            return new List<CommentDTO>();
        }
    }
}
