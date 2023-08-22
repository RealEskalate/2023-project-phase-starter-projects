using MediatR;
using SocialSync.Application.Dtos.Authentication;

namespace SocialSync.Application.Features.Authentication.Requests
{
    public class LoginUserRequest : IRequest<LoginResponseDto>
    {
        public LoginUserDto LoginUserDto { get; set; } = null!;
    }
}