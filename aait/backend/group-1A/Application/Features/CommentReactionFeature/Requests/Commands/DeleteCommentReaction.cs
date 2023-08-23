using MediatR;

namespace Application.Features.CommentReactionFeatures.Requests.Commands
{
    public class CommentReactionDeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
