using Application.DTO.CommentDTO;
using MediatR;

namespace Application.Features.Comment.Requests.Queries;

public class GetCommentsByPostIdRequest : IRequest<List<CommentDto> >
{
   public int PostId { get; set; }
}