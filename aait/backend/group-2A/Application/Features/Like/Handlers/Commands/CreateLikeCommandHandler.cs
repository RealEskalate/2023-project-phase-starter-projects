
using MediatR;
using Application.Contracts.Persistance;
using Application.DTO.Like.Validator;
using Application.Exceptions;
using AutoMapper;

namespace Application.Features.Like.Handlers.Commands
{
    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper){
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            var validator = new LikedDtoValidator(_unitOfWork.userRepository, _unitOfWork.postRepository);
            var validationResult = await validator.ValidateAsync(request.Like);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            await _unitOfWork.likeRepository.LikePost(_mapper.Map<Domain.Entities.Like>(request.Like));
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}