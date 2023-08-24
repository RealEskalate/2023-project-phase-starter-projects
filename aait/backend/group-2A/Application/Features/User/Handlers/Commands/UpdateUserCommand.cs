using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.UserDTO.Validator;
using Application.Exceptions;
using Application.Features.User.Request.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
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

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken){
            var validator = new UpdateUserDTOValidator(_unitOfWork.userRepository);
            var validationResult = await validator.ValidateAsync(request.updateUser);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var user = await _unitOfWork.userRepository.Get(request.updateUser.Id);
            _mapper.Map(request.updateUser, user);
            if (await _authService.Update(request.updateUser, user.Email)){
                throw new Exception("Can't be Comleted");

            }
            user = _mapper.Map<Domain.Entities.User>(request.updateUser);
            await _unitOfWork.userRepository.Update(user);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}