using Application.DTOs.Comments;
using MediatR;

namespace Application.Features.Comments.Requests.Commands;

public class CreateCommentRequest : IRequest<CommentContentDto>
{
    public CreateCommentDto Comment { get; set; }
}