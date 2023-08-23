using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialSync.Application.Contracts.Infrastructure;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Application.DTOs.Authentication.Validators;
using SocialSync.Application.Features.Authentication.Requests.Commands;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Authentication.Handlers.Queries;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, LoggedInUserDto>
{
    private IUnitOfWork _unitOfWork;
    private IJwtGenerator _jwtGenerator;
    private IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;

    public RegisterUserCommandHandler(
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
        RegisterUserCommand request,
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
            await _unitOfWork.UserRepository.UsernameExists(request.RegisterUserDto.Username)
            || await _unitOfWork.UserRepository.EmailExists(request.RegisterUserDto.Email);

        if (userExists == true)
            throw new Exception();

        // Create and persiste the user
        var user = _mapper.Map<User>(request.RegisterUserDto);

        // Hash the password
        var hashedPassword = _passwordHasher.HashPassword(user, user.Password);
        user = await _unitOfWork.UserRepository.AddAsync(user);

        // Convert back to the dto
        var userDto = _mapper.Map<UserDto>(user);

        // Generate a jwt token
        var token = _jwtGenerator.Generate(user);

        return new LoggedInUserDto { UserDto = userDto, Token = token };
    }
}
