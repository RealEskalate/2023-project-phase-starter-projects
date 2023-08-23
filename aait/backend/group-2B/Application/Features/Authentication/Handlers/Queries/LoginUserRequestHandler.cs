using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Infrastructure;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Application.Features.Authentication.Requests.Queries;

namespace SocialSync.Application.Features.Authentication.Handlers.Queries;

public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoggedInUserDto>
{
    private IUserRepository _userRepository;
    private IJwtGenerator _jwtGenerator;
    private IMapper _mapper;

    public LoginUserRequestHandler(IUserRepository userRepository, IJwtGenerator jwtGenerator, IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
        _mapper = mapper;
    }

    public async Task<LoggedInUserDto> Handle(
        LoginUserRequest request,
        CancellationToken cancellationToken
    ) {
      // Check is user exists
      var userExists = await _userRepository.UsernameExists(request.LoginUserDto.Username);
      if (!userExists)
        throw new Exception();

      // Check Password
      // TODO: Salting and Encryption
      var user = await _userRepository.GetByUsername(request.LoginUserDto.Username);
      if (user.Password != request.LoginUserDto.Password)
        throw new Exception();

      // Convert to dto
      var userDto = _mapper.Map<UserDto>(user);

      // Generate JWT
      var token = _jwtGenerator.Generate(user);

      // Build the return DTO
      return new LoggedInUserDto { UserDto = userDto, Token = token };
     }
}
