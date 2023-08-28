using Application.Responses;
using MediatR;

namespace Application.Features.Comment.Requests.Commands;

public class DeleteCommentCommand : IRequest<BaseCommandResponse<Unit>>
{
    public int Id { get; set; }
    public int UserId{ get; set; }
}