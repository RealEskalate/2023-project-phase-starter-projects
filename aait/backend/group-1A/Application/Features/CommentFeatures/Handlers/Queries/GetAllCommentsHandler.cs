using Application.DTO.CommentDTOS.DTO;
using Application.Features.CommentFeatures.Requests.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Queries
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<CommentDTO>>
    {
        public Task<List<CommentDTO>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            // Implement  logic to retrieve all comments
            // var comments = await commentRepository.GetAllCommentsAsync();
            // return comments;
            return Task.FromResult(new List<CommentDTO>());
        }
    }
}
