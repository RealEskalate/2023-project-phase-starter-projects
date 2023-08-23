using Application.Contracts;
using Application.DTO.CommentDTOS.DTO;
using Application.Features.CommentFeatures.Requests.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Queries
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, CommentDTO>
    {
        private readonly ICommentRepository _commentRepository; // Inject the repository here

        public GetCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentDTO> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(request.CommentId); // Replace with actual repository method
            return comment;
        }
    }
}
