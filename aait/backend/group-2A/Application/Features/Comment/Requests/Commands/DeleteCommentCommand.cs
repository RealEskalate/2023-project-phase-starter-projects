using Application.Responses;
using MediatR;

namespace Application.Features.Comment.Requests.Commands;

public class DeleteCommentCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
}