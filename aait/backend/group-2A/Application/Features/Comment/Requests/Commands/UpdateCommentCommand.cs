using Application.DTO.CommentDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.Comment.Requests.Commands;

public class UpdateCommentCommand : IRequest<BaseCommandResponse<Unit>>
{
    public UpdateCommentDto UpdateCommentDto { get; set; }
}