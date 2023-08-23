using Application.DTOs.Comments;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Requests.Queries;

public class GetCommentRequest : IRequest<Comment>
{
    public int Id { get; set; }
}