
using Application.Features.Like.Request.Commands;
using MediatR;
using Application.Contracts.Persistance;
using AutoMapper;

namespace Application.Features.Like.Handlers.Commands
{
    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, Unit>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly Mapper _mapper;

        public DeleteLikeCommandHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<Unit> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
        {
             await _likeRepository.UnlikePost(_mapper.Map<Domain.Entities.Like>(request.like));
             return Unit.Value;
        }
    }
}