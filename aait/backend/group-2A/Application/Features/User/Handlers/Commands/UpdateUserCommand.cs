using System.Threading;
using System.Threading.Tasks;
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

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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
            // var user = _mapper.Map<Domain.Entities.User>(request.updateUser);
            await _unitOfWork.userRepository.Update(user);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}