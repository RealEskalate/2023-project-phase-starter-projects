using MediatR;
using SocialSync.Application.Dtos.Authentication;

namespace SocialSync.Application.Features.Authentication.Requests
{
    public class LoginUserRequest : IRequest<LoginResponseDto>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}