using Application.Contracts;
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
        private readonly ICommentRepository _commentRepository; // Inject the repository here

        public GetAllCommentsQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<CommentDTO>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAllCommentsAsync(); // Replace with actual repository method
            return comments;
        }
    }
}
