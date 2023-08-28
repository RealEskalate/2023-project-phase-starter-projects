using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.Authentication;

namespace SocialSync.Application.Features.Authentication.Requests.Commands;

public class RegisterUserCommand : IRequest<CommonResponse<LoggedInUserDto>>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}
