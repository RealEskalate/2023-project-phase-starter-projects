using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Infrastructure;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Application.DTOs.Authentication.Validators;
using SocialSync.Application.Features.Authentication.Requests.Queries;

namespace SocialSync.Application.Features.Authentication.Handlers.Queries;

public class LoginUserRequestHandler
    : IRequestHandler<LoginUserRequest, CommonResponse<LoggedInUserDto>>
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

    public async Task<CommonResponse<LoggedInUserDto>> Handle(
        LoginUserRequest request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new LoginUserDtoValidator();
        var validationResult = dtoValidator.Validate(request.LoginUserDto);

        if (validationResult.IsValid == false)
        {
            return new CommonResponse<LoggedInUserDto>
            {
                IsSuccess = false,
                Message = "User login failed.",
                Error = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
            };
        }

        // Check user existence and password
        var existingUser = await _unitOfWork.UserRepository.GetByUsername(request.LoginUserDto.Username);
        if (existingUser == null)
        {
            return new CommonResponse<LoggedInUserDto>
            {
                IsSuccess = false,
                Message = "User login failed.",
                Error = new List<string> { "User not found." }
            };
        }

        var passwordsMatch = _passwordHasher.VerifyPassword(
            existingUser.Password,
            request.LoginUserDto.Password
        );

        if (passwordsMatch == false)
        {
            return new CommonResponse<LoggedInUserDto>
            {
                IsSuccess = false,
                Message = "User login failed.",
                Error = new List<string> { "Username or Password is incorrect." }
            };
        }
        var User = _mapper.Map<UserDto>(existingUser);
        var token = _jwtGenerator.Generate(existingUser);

        return new CommonResponse<LoggedInUserDto>
        {
            IsSuccess = true,
            Message = "User login successfull.",
            Value = new LoggedInUserDto { UserDto = User, Token = token }
        };
    }
}
