using MediatR;

namespace Application.Features.CommentReactionFeatures.Requests.Commands
{
    public class CommentReactionUpdateCommand : IRequest
    {
        // Properties for updating a comment reaction
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }
    }
}
