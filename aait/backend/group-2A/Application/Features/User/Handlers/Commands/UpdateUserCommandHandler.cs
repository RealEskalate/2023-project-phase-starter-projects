using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.UserDTO.Validator;
using Application.Exceptions;
using Application.Features.User.Request.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateUserCommand request, CancellationToken cancellationToken){

            try{
                var validator = new UpdateUserDTOValidator(_unitOfWork.userRepository);
                var validationResult = await validator.ValidateAsync(request.updateUser);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult);
                }

                var user = await _unitOfWork.userRepository.Get(request.updateUser.Id);
                _mapper.Map(request.updateUser, user);
                await _authService.Update(request.updateUser, user.Email);
                await _unitOfWork.userRepository.Update(user);
                if (await _unitOfWork.Save() == 0) throw new ServerErrorException("Something went wrong");
                return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value);
            }
            catch(Exception ex){
                return BaseCommandResponse<Unit>.FailureHandler(ex);

            }
        }
    }
}