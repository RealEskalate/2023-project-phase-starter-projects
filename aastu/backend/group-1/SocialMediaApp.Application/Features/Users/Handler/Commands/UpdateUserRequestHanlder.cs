using FluentValidation.Results;
using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Users.Validations;
using SocialMediaApp.Application.Features.Users.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Exceptions;

namespace SocialMediaApp.Application.Features.Users.Handler.Commands
{
    public class UpdateUserCommandRequestHandler: IRequestHandler<UpdateUserCommandRequest, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandRequestHandler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new ValidateUpdateUserDto(_userRepository);

            var validationResult = await validator.ValidateAsync(request.UpdateUserDto);

            if(validationResult.IsValid == false)
                throw new ValidationException(validationResult);


            var user = await _userRepository.GetById(request.UpdateUserDto.Id);
            _mapper.Map(request.UpdateUserDto, user);
            await _userRepository.Update(user);
            return Unit.Value;
        }
    }
}