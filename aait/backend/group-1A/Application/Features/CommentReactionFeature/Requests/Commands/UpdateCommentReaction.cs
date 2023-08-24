using MediatR;

namespace Application.Features.CommentReactionFeatures.Requests.Commands
{
    public class CommentReactionUpdateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool Like { get; set; }
        public int userId { get; set; }
        public bool Dislike { get; set; }
    }
}
