using Application.DTO.CommentDTO;
using MediatR;

namespace Application.Features.Comment.Requests.Queries;

public class GetCommentRequest : IRequest<CommentDto>
{
    public int commentId { get; set; }
}