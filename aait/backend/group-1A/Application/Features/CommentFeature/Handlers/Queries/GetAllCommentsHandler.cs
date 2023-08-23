using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Queries
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<CommentDTO>>
    {
        public async Task<List<CommentDTO>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            // Implement  logic to retrieve all comments
            // var comments = await commentRepository.GetAllCommentsAsync();
            // return comments;
            return new List<CommentDTO>();
        }
    }
}
