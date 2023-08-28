using AutoMapper;
using Application.DTOs.Users.Validation;
using Application.features.Users.Request.command;

using MediatR;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Domain.Entities;

namespace Application.features.Users.Handler.Command
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserRequestHandler(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserDtoValidator();

            var validationResult = validator.Validate(request.UpdateUserDto);

            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var user = _mapper.Map<User>(request.UpdateUserDto);
            await _userRepository.UpdateUser(user);

            return Unit.Value;
        }
    }
}
