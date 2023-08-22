using System.Net;
using Application.Dtos.Authentication;
using Application.Features.Authentication.Requests;
using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Authentication.Handlers.Commands;
public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, RegisterResponseDto>
{

    readonly IUserRepository _userRepository;
    readonly IMapper _mapper;
    readonly IJwtGenerator _jwtGenerator;

    public RegisterUserRequestHandler( IUserRepository userRepository, IMapper mapper, IJwtGenerator jwtGenerator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtGenerator = jwtGenerator;

    }
   public async Task<RegisterResponseDto> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        // Check if user exists
        if (await _userRepository.UserExistsAsync(request.Email))
        {
            throw new Exception("User already exists");
        }

        // Map request to user
        var user = _mapper.Map<User>(request);

        // Register user
        var registeredUser = await _userRepository.RegisterUserAsync(user, request.Password);
        

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