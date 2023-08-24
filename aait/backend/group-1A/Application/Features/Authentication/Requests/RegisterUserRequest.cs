using Application.Dtos.Authentication;
using MediatR;
using SocialSync.Application.Dtos.Authentication;

namespace Application.Features.Authentication.Requests;

public class RegisterUserRequest : IRequest<RegisterResponseDto>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}
