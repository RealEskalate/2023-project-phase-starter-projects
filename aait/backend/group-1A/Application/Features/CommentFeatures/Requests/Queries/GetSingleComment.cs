using Application.DTO.CommentDTOS.DTO;
using MediatR;

namespace Application.Features.CommentFeatures.Requests.Queries
{
    public class GetCommentQuery : IRequest<CommentDTO>
    {
        public int CommentId { get; set; }
    }
}
