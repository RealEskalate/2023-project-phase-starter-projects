using Application.DTOs.Comments;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Requests.Queries;

public class GetCommentsByPostIdRequest : IRequest<List<CommentContentDto>>
{
    public int PostId { get; set; }
}