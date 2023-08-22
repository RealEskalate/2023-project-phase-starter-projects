using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Like.Request.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Like.Handlers.Commands
{
    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, Unit>
    {
        private readonly ILikeRepository _likeRepository;

        public DeleteLikeCommandHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<uint> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
        {
            var like = await _likeRepository.GetById(request.Id);

            if (like == null)
            {
                throw new NotFoundException("Like not found.");
            }

            await _likeRepository.Delete(like);

            return like.Id;
        }
    }
}