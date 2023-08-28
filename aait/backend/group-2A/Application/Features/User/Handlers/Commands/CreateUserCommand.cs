using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.Post.Validation;
using Application.DTO.UserDTO.Validator;
using Application.Exceptions;
using Application.Features.User.Request.Commands;
using Application.Model;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse<AuthResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;


        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
        {
            _mapper = mapper; 
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<BaseCommandResponse<AuthResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken){
            try{
                var validator = new CreateUserDTOValidator(_unitOfWork.userRepository);
                var validationResult = await validator.ValidateAsync(request.CreateUser);
                if (!validationResult.IsValid){
                    throw new ValidationException(validationResult);
                }

                var user = _mapper.Map<Domain.Entities.User>(request.CreateUser);
                await _unitOfWork.userRepository.Add(user);
                var token = await _authService.Register(request.CreateUser, _unitOfWork.userRepository);
                if (await _unitOfWork.Save() == 0) throw new ServerErrorException("Something Went Wrong");
                var res =  new AuthResponse(){ Id = user.Id, Email = user.Email, Username = user.UserName };
                return BaseCommandResponse<AuthResponse>.SuccessHandler(res);
            }
            catch(Exception ex){
                return BaseCommandResponse<AuthResponse>.FailureHandler(ex);
            }
        }
    }
}
