using Application.DTO.CommentDTO;
using MediatR;

namespace Application.Features.Comment.Requests.Commands;

public class CreateCommentCommand : IRequest<int>
{
    public CreateCommentDto CommentDto { get; set; }
}