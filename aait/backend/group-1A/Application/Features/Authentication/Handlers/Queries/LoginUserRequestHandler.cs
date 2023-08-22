using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.Dtos.Authentication;
using SocialSync.Application.Features.Authentication.Requests;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Authentication.Handlers.Queries;

public class LoginUserRequestHanlder : IRequestHandler<LoginUserRequest,LoginResponseDto>{

    readonly IAuthRepository _authRepository;
    readonly IMapper _mapper;
    readonly IJwtGenerator _jwtGenerator;

    public LoginUserRequestHanlder(IAuthRepository authRepository, IMapper mapper, IJwtGenerator jwtGenerator)
    {
        _authRepository = authRepository;
        _mapper = mapper;
        _jwtGenerator = jwtGenerator;
    }
    public async Task<LoginResponseDto> Handle(LoginUserRequest request, CancellationToken cancellationToken){
        // Check if user exists
        if (!await _authRepository.UserExists(request.LoginUserDto.Email))
        {
            throw new Exception("User does not exist");
        }
        
        // Login user
        var user = await _authRepository.LoginUser(_mapper.Map<User>(request.LoginUserDto));
        

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