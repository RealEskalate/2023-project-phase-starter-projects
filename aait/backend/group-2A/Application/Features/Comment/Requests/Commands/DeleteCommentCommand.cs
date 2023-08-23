using MediatR;

namespace Application.Features.Comment.Requests.Commands;

public class DeleteCommentCommand : IRequest<Unit>
{
    public int Id { get; set; }
}