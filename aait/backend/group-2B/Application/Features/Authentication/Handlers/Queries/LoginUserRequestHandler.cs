using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Infrastructure;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Application.Features.Authentication.Requests.Queries;

namespace SocialSync.Application.Features.Authentication.Handlers.Queries;

public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoggedInUserDto>
{
    private IUnitOfWork _unitOfWork;
    private IJwtGenerator _jwtGenerator;
    private IMapper _mapper;

    public LoginUserRequestHandler(IUnitOfWork unitOfWork, IJwtGenerator jwtGenerator, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _jwtGenerator = jwtGenerator;
        _mapper = mapper;
    }

    public async Task<LoggedInUserDto> Handle(
        LoginUserRequest request,
        CancellationToken cancellationToken
    ) {
      // Check is user exists
      var userExists = await _unitOfWork.UserRepository.UsernameExists(request.LoginUserDto.Username);
      if (!userExists)
        throw new Exception();

      // Check Password
      // TODO: Salting and Encryption
      var user = await _unitOfWork.UserRepository.GetByUsername(request.LoginUserDto.Username);
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
