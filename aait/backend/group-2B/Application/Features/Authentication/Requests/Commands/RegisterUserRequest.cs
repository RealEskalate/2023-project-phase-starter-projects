using MediatR;
using SocialSync.Application.DTOs.Authentication;

namespace SocialSync.Application.Features.Authentication.Requests.Commands;

public class RegisterUserRequest : IRequest<RegisteredUserDto>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}
