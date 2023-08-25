using MediatR;
using SocialSync.Application.DTOs.Authentication;

namespace SocialSync.Application.Features.Authentication.Requests.Commands;

public class RegisterUserCommand : IRequest<LoggedInUserDto>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}
