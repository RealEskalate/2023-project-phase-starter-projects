using MediatR;
using SocialMediaApp.Application.DTOs.Users;
using SocialMediaApp.Application.Responses;

namespace SocialMediaApp.Application.Features.Users.Request.Commands;

public class CreateUserRequest:IRequest<BaseResponseClass>
{
    public CreateUserDto CreateUserDto { get; set; } = null!;

}
