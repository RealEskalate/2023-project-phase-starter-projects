
using Application.Features.Like.Request.Commands;
using MediatR;
using Application.Contracts.Persistance;
using AutoMapper;

namespace Application.Features.Like.Handlers.Commands
{
    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("-------------------$");
             await _unitOfWork.likeRepository.UnlikePost(_mapper.Map<Domain.Entities.Like>(request.like));
             await _unitOfWork.Save();
             return Unit.Value;
        }
    }
}