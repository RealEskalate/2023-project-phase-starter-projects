using Application.DTO.CommentDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.Comment.Requests.Queries;

public class GetCommentRequest : IRequest<BaseCommandResponse<CommentDto>>
{
    public int commentId { get; set; }
}