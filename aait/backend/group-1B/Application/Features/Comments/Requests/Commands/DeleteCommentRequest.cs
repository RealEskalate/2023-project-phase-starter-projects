using MediatR;

namespace Application.Features.Comments.Requests.Commands;

public class DeleteCommentRequest : IRequest<Unit>
{
    public int Id { get; set; }
}