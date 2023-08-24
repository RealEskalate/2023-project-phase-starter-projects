using Application.DTO.CommentDTOS.DTO;
using MediatR;

namespace Application.Features.CommentFeatures.Requests.Queries
{
    public class GetCommentsForPostQuery : IRequest<List<CommentDTO>>
    {
        public int PostId { get; set; }
    }
}
