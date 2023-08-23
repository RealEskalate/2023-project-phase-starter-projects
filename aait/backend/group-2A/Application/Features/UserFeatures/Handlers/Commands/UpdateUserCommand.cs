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
        private readonly IUserRepository _userRepository;
        private readonly Mapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, Mapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken){
            var validator = new UpdateUserDTOValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.updateUser);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            
            var user = await _userRepository.Get(request.updateUser.Id);
            _mapper.Map(request.updateUser, user);
            // var user = _mapper.Map<Domain.Entities.User>(request.updateUser);
            await _userRepository.Update(user);
            return Unit.Value;
        }
    }
}