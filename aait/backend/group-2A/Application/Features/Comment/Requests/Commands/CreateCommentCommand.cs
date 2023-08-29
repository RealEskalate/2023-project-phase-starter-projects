using Application.DTO.CommentDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.Comment.Requests.Commands;

public class CreateCommentCommand : IRequest<BaseCommandResponse<int>>
{
    public CreateCommentDto CommentDto { get; set; }
}