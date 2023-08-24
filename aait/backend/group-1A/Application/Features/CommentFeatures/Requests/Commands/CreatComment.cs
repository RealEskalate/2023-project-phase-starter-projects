using MediatR;
using Application.DTO.CommentDTOS.DTO;
using Application.DTO.CommentDTO.DTO;

namespace Application.Features.CommentFeatures.Requests.Commands
{
    public class CommentCreateCommand : IRequest<CommentDTO>
    {
        public string Message { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public CommentCreateDTO CommentDTO { get; internal set; }
    }
}
