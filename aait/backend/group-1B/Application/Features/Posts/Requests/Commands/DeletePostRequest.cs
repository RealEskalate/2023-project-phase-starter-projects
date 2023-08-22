using MediatR;

namespace Application.Features.Posts.Requests.Commands;

public class DeletePostRequest : IRequest<Unit>
{
    public int Id { get; set; }
}