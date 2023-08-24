using Application.Contracts;
using Application.Features.CommentReactionFeatures.Requests.Commands;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentReactionFeatures.Handlers.Commands
{
    public class CommentReactionUpdateCommandHandler : IRequestHandler<CommentReactionUpdateCommand, Unit>
    {
        private readonly ICommentReactionRepository _commentReactionRepository;
        private readonly IMapper _mapper;

        public CommentReactionUpdateCommandHandler(ICommentReactionRepository commentReactionRepository, IMapper mapper)
        {
            _commentReactionRepository = commentReactionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CommentReactionUpdateCommand request, CancellationToken cancellationToken)
        {
            // Fetch the existing comment reaction by ID
            var existingCommentReaction = await _commentReactionRepository.GetCommentReactionByIdAsync(request.Id);

            // Update the properties of the existing comment reaction
            existingCommentReaction.Like = request.Like;
            existingCommentReaction.Dislike = request.Dislike;

            // Update the comment reaction in the repository
            await _commentReactionRepository.UpdateCommentReactionAsync(existingCommentReaction);

            return Unit.Value;
        }
    }
}
