using Application.DTO.CommentDTO.DTO;
using Application.Response;
using MediatR;

namespace Application.Features.CommentFeatures.Requests.Queries
{
    public class GetCommentsForPostQuery : IRequest<BaseResponse<List<CommentResponseDTO>>>
    {
        public int PostId { get; set; }
    }
}
