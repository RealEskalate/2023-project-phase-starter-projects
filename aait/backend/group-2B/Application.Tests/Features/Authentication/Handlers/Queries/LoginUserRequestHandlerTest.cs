using AutoMapper;
using HRLeaveManagement.Application.Profiles;
using Microsoft.Extensions.Options;
using Moq;
using Shouldly;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Infrastructure;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Application.Features.Authentication.Handlers.Queries;
using SocialSync.Application.Features.Authentication.Requests.Commands;
using SocialSync.Application.Features.Authentication.Requests.Queries;
using SocialSync.Application.Tests.Mocks;
using SocialSync.Infrastructure.DateTimeService;
using SocialSync.Infrastructure.JWT;
using SocialSync.Infrastructure.PasswordService;

namespace SocialSync.Application.Tests.Features.Authentication.Handlers.Commands;

public class LoginUserRequestHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly RegisterUserCommandHandler _registerHandler;
    private readonly LoginUserRequestHandler _handler;
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserRequestHandlerTest()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<AuthenticationMappingProfile>();
        });
        var jwtSettings = new JwtSettings
        {
            Secret = "Social-Sync-JWT-Secret-and-then-some",
            Issuer = "SocialSync",
            Audience = "SocialSync",
            ExpiryMinutes = 60
        };
        var jwtOptions = Options.Create(jwtSettings);
        _mapper = mapperConfig.CreateMapper();
        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        _jwtGenerator = new JwtGenerator(new DateTimeProvider(), jwtOptions);
        _passwordHasher = new PasswordHasher();
        _handler = new LoginUserRequestHandler(
            _mockUnitOfWork.Object,
            _jwtGenerator,
            _mapper,
            _passwordHasher
        );

        _registerHandler = new RegisterUserCommandHandler(
            _mockUnitOfWork.Object,
            _jwtGenerator,
            _mapper,
            _passwordHasher
        );
    }

    [Fact]
    public async Task Valid_RegisterNewUser()
    {
        var newUser = new RegisterUserDto
        {
            FirstName = "User4",
            LastName = "User4",
            Email = "User4@gmail.com",
            Username = "User4",
            Password = "User4password",
            Phone = "1234567890",
        };

        await _registerHandler.Handle(
            new RegisterUserCommand { RegisterUserDto = newUser },
            CancellationToken.None
        );

        var result = await _handler.Handle(
            new LoginUserRequest
            {
                LoginUserDto = new LoginUserDto { Username = "User4", Password = "User4password" }
            },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<LoggedInUserDto>>();
        result.IsSuccess.ShouldBeTrue();
        result.Value.Token.ShouldNotBeNullOrEmpty();
    }

    [Fact]
    public async Task Invalid_IncorrectPasswordRegisterNewUser()
    {
        var newUser = new RegisterUserDto
        {
            FirstName = "User4",
            LastName = "User4",
            Email = "User4@email.com", // Not an email
            Username = "User4",
            Password = "User4password",
            Phone = "1234567890",
        };

        await _registerHandler.Handle(
            new RegisterUserCommand { RegisterUserDto = newUser },
            CancellationToken.None
        );

        var result = await _handler.Handle(
            new LoginUserRequest
            {
                LoginUserDto = new LoginUserDto { Username = "User4", Password = "User4passwordiswrong" }
            },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<LoggedInUserDto>>();
        result.IsSuccess.ShouldBeFalse();
        result.Value.ShouldBeNull();
    }

    [Fact]
    public async Task Invalid_IncorrectUsernameRegisterNewUser()
    {
        var newUser = new RegisterUserDto
        {
            FirstName = "User4",
            LastName = "User4",
            Email = "User4@email.com", // Not an email
            Username = "User4",
            Password = "User4password",
            Phone = "1234567890",
        };

        await _registerHandler.Handle(
            new RegisterUserCommand { RegisterUserDto = newUser },
            CancellationToken.None
        );

        var result = await _handler.Handle(
            new LoginUserRequest
            {
                LoginUserDto = new LoginUserDto { Username = "User4iswrong", Password = "User4password" }
            },
            CancellationToken.None
        );

        result.ShouldBeOfType<CommonResponse<LoggedInUserDto>>();
        result.IsSuccess.ShouldBeFalse();
        result.Value.ShouldBeNull();
    }
}
