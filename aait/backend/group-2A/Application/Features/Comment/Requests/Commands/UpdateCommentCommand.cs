using Application.DTO.CommentDTO;
using MediatR;

namespace Application.Features.Comment.Requests.Commands;

public class UpdateCommentCommand : IRequest<Unit>
{
    public UpdateCommentDto UpdateCommentDto { get; set; }
}