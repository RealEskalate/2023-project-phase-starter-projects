using MediatR;

namespace Application.Features.CommentReactionFeatures.Requests.Commands
{
    public class CommentReactionCreateCommand : IRequest<int>
    {
        // Properties for creating a comment reaction
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }
    }
}
