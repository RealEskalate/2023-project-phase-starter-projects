using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Infrastructure;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Application.DTOs.Authentication.Validators;
using SocialSync.Application.Features.Authentication.Requests.Queries;
using SocialSync.Application.Exceptions;

namespace SocialSync.Application.Features.Authentication.Handlers.Queries;

public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoggedInUserDto>
{
    private IUnitOfWork _unitOfWork;
    private IJwtGenerator _jwtGenerator;
    private IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserRequestHandler(
        IUnitOfWork unitOfWork,
        IJwtGenerator jwtGenerator,
        IMapper mapper,
        IPasswordHasher passwordHasher
    )
    {
        _unitOfWork = unitOfWork;
        _jwtGenerator = jwtGenerator;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoggedInUserDto> Handle(
        LoginUserRequest request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new LoginUserDtoValidator();
        var validationResult = dtoValidator.Validate(request.LoginUserDto);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        // Check user existence and password
        var user = await _unitOfWork.UserRepository.GetByUsername(request.LoginUserDto.Username);
        if (user == null)
            throw new NotFoundException("User not found.");

        var passwordsMatch = _passwordHasher.VerifyPassword(
            user.Password,
            request.LoginUserDto.Password
        );

        if (passwordsMatch == false)
            throw new BadRequestException("Username or Password is incorrect.");

        var userDto = _mapper.Map<UserDto>(user);
        var token = _jwtGenerator.Generate(user);

        return new LoggedInUserDto { UserDto = userDto, Token = token };
    }
}
