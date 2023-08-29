using Application.DTO.CommentDTO.DTO;
using Application.Response;
using MediatR;

namespace Application.Features.CommentFeatures.Requests.Queries
{
    public class GetSingleCommentQuery : IRequest<BaseResponse<CommentResponseDTO>>
    {
        public int Id { get; set; }
    }
}
