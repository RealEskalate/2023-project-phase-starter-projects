using MediatR;
using Application.DTO.CommentDTO.DTO;
using Application.Response;

namespace Application.Features.CommentFeatures.Requests.Commands
{
    public class CommentCreateCommand : IRequest<BaseResponse<CommentResponseDTO>>
    {
        public int userId { get; set; }
        public CommentCreateDTO NewCommentData { get; set; } = null!;
    }
}
