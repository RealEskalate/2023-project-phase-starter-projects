using Application.DTO.CommentDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.Comment.Requests.Queries;

public class GetCommentsByPostIdRequest : IRequest<BaseCommandResponse<List<CommentDto>>>
{
   public int PostId { get; set; }
   public int PageNumber{ get; set; } = 0;
   public int PageSize{ get; set; } = 10;
}