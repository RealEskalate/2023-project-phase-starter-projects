using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialSync.Application.Contracts.Infrastructure;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Application.DTOs.Authentication.Validators;
using SocialSync.Application.Features.Authentication.Requests.Queries;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Authentication.Handlers.Queries;

public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoggedInUserDto>
{
    private IUnitOfWork _unitOfWork;
    private IJwtGenerator _jwtGenerator;
    private IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;

    public LoginUserRequestHandler(
        IUnitOfWork unitOfWork,
        IJwtGenerator jwtGenerator,
        IMapper mapper,
        IPasswordHasher<User> passwordHasher
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
        // Validate the DTO
        var dtoValidator = new LoginUserDtoValidator();
        var validationResult = dtoValidator.Validate(request.LoginUserDto);

        if (validationResult.IsValid == false)
            throw new Exception();

        // Check is user exists
        var user = await _unitOfWork.UserRepository.GetByUsername(request.LoginUserDto.Username);
        if (user == null)
            throw new Exception();

        // Check Password
        // Verify the password
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(
            user,
            user.Password,
            request.LoginUserDto.Password
        );

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
            throw new Exception();

        if (passwordVerificationResult == PasswordVerificationResult.SuccessRehashNeeded)
        {
            // Update the user by rehashing the password
            user.Password = _passwordHasher.HashPassword(user, request.LoginUserDto.Password);
            await _unitOfWork.UserRepository.UpdateAsync(user);
        }

        // Convert to dto
        var userDto = _mapper.Map<UserDto>(user);

        // Generate JWT
        var token = _jwtGenerator.Generate(user);

        // Build the return DTO
        return new LoggedInUserDto { UserDto = userDto, Token = token };
    }
}
