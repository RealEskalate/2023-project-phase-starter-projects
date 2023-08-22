using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.Dtos.Authentication;
using SocialSync.Application.Features.Authentication.Requests;

namespace SocialSync.Application.Features.Authentication.Handlers.Queries;

public class LoginUserRequestHanlder : IRequestHandler<LoginUserRequest,LoginResponseDto>{

    readonly IUserRepository _userRepository;
    readonly IMapper _mapper;
    readonly IJwtGenerator _jwtGenerator;

    public LoginUserRequestHanlder(IUserRepository userRepository, IMapper mapper, IJwtGenerator jwtGenerator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtGenerator = jwtGenerator;
    }
    public async Task<LoginResponseDto> Handle(LoginUserRequest request, CancellationToken cancellationToken){
        // Check if user exists
        if (!await _userRepository.UserExistsAsync(request.Email))
        {
            throw new Exception("User does not exist");
        }

        // Login user
        var user = await _userRepository.LoginUserAsync(request.Email, request.Password);

        // Generate token
        var token = await _jwtGenerator.CreateTokenAsync(user);

        return new LoginResponseDto
        {
            UserName = user.Username,
            Email = user.Email,
            Token = token
        };
    }
}