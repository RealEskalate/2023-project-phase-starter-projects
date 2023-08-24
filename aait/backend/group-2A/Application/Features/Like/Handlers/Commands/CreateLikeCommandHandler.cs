
using MediatR;
using Application.Contracts.Persistance;
using Application.DTO.Like.Validator;
using Application.Exceptions;
using AutoMapper;
using Application.Responses;

namespace Application.Features.Like.Handlers.Commands
{
    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper){
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new LikedDtoValidator(_unitOfWork.userRepository, _unitOfWork.postRepository);
            var validationResult = await validator.ValidateAsync(request.like);
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Like unsuccessful";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            await _unitOfWork.likeRepository.LikePost(_mapper.Map<Domain.Entities.Like>(request.like));
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Like Successful";

            return response;
        }
    }
}