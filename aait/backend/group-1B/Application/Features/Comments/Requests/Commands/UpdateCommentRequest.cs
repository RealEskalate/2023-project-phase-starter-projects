using Application.DTOs.Comments;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Requests.Commands;

public class UpdateCommentRequest : IRequest<Comment>
{
    public UpdateCommentDto Comment;
}