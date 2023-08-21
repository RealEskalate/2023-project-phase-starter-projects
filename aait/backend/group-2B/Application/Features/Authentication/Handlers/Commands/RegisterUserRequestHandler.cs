using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Infrastructure;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Application.DTOs.Authentication.Validators;
using SocialSync.Application.Features.Authentication.Requests.Commands;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Authentication.Handlers.Queries;

public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, RegisteredUserDto>
{
    private IUserRepository _userRepository;
    private IJwtGenerator _jwtGenerator;
    private IMapper _mapper;

    public RegisterUserRequestHandler(IUserRepository userRepository, IJwtGenerator jwtGenerator, IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
        _mapper = mapper;
    }

    public async Task<RegisteredUserDto> Handle(
        RegisterUserRequest request,
        CancellationToken cancellationToken
    )
    {
        // Validate the DTO
        var dtoValidator = new RegisterUserDtoValidator();
        var validationResult = dtoValidator.Validate(request.RegisterUserDto);

        if (validationResult.IsValid == false)
            throw new Exception();

        // Check that another user doesn't exist with the same username or email
        var userExists =
            await _userRepository.UsernameExists(request.RegisterUserDto.Username)
            || await _userRepository.EmailExists(request.RegisterUserDto.Email);

        if (userExists == true)
          throw new Exception();

        // TODO: Create and persiste the user
        var user = _mapper.Map<User>(request.RegisterUserDto);
        await _userRepository.Create(user);

        // Generate a jwt token
        var token = _jwtGenerator.Generate(user);

        // Prepare the return dto
        return new RegisteredUserDto { User = user, Token = token };
    }
}
