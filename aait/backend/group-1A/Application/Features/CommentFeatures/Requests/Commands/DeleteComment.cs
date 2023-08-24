using MediatR;

namespace Application.Features.CommentFeatures.Requests.Commands
{
    public class CommentDeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
