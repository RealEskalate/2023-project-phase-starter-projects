using MediatR;

namespace Application.Features.CommentFeatures.Requests.Commands
{
    public class CommentUpdateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
