using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Infrastructure;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Application.DTOs.Authentication.Validators;
using SocialSync.Application.Exceptions;
using SocialSync.Application.Features.Authentication.Requests.Commands;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Authentication.Handlers.Queries;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, LoggedInUserDto>
{
    private IUnitOfWork _unitOfWork;
    private IJwtGenerator _jwtGenerator;
    private IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandler(
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
        RegisterUserCommand request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new RegisterUserDtoValidator();
        var validationResult = dtoValidator.Validate(request.RegisterUserDto);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var userExists = await _unitOfWork.UserRepository.UsernameExists(
            request.RegisterUserDto.Username
        );

        if (userExists == true)
            throw new BadRequestException("Username Exists.");

        userExists = await _unitOfWork.UserRepository.EmailExists(request.RegisterUserDto.Email);

        if (userExists == true)
            throw new BadRequestException("Email Exists.");

        var user = _mapper.Map<User>(request.RegisterUserDto);
        user.Password = _passwordHasher.HashPassword(user.Password);

        user = await _unitOfWork.UserRepository.AddAsync(user);
        await _unitOfWork.SaveAsync();

        var userDto = _mapper.Map<UserDto>(user);
        var token = _jwtGenerator.Generate(user);

        return new LoggedInUserDto { UserDto = userDto, Token = token };
    }
}
