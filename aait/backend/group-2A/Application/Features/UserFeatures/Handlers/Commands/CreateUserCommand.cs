using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.DTO.Post.Validation;
using Application.DTO.UserDTO.Validator;
using Application.Exceptions;
using Application.Features.User.Request.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly Mapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken){
            var validator = new CreateUserDTOValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.CreateUser);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var user = _mapper.Map<Domain.Entities.User>(request.CreateUser);
            await _userRepository.Add(user);
            return user.Id;
        }
    }
}
