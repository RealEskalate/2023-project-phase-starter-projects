using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.Dtos.Authentication;
using Application.Features.Authentication.Requests;
using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.Dto.Authentication.validator;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Authentication.Handlers.Commands;
public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, RegisterResponseDto>
{

    readonly IAuthRepository _authRepository;
    readonly IMapper _mapper;
    readonly IJwtGenerator _jwtGenerator;

    public RegisterUserRequestHandler( IAuthRepository authRepository, IMapper mapper, IJwtGenerator jwtGenerator)
    {
        _authRepository = authRepository;
        _mapper = mapper;
        _jwtGenerator = jwtGenerator;

    }
   public async Task<RegisterResponseDto> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {

        
        var validator = new RegisterUserDtoValidator();
        var validationResult = await validator.ValidateAsync(request.RegisterUserDto, cancellationToken);
        // Check if user exists
        if (await _authRepository.UserExists(request.RegisterUserDto.Email))
        {
            throw new Exception("User already exists");
        }

        // Map request to user
        var user = _mapper.Map<User>(request.RegisterUserDto);

        // Register user
        var registeredUser = await _authRepository.RegisterUser(user);
        

        // Generate token
        var token = await _jwtGenerator.CreateTokenAsync(registeredUser);

        
        return new RegisterResponseDto
        {   
            FirstName = registeredUser.FirstName,
            LastName = registeredUser.LastName,
            UserName = registeredUser.Username,
            Email = registeredUser.Email,
            Token = token
        };

    }
}