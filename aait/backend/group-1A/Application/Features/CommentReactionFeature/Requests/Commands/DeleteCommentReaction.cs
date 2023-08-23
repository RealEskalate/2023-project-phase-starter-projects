using MediatR;

namespace Application.Features.CommentReactionFeatures.Requests.Commands
{
    public class CommentReactionDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
