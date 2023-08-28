using Application.DTO.CommentDTO.DTO;
using Application.Response;
using MediatR;

namespace Application.Features.CommentFeatures.Requests.Commands
{
    public class UpdateCommentCommand : IRequest<BaseResponse<CommentResponseDTO>>
    {
        public int Id { get; set; }

        public int userId { get; set; }

        public CommentUpdateDTO CommentData { get; set; }
    }
}
