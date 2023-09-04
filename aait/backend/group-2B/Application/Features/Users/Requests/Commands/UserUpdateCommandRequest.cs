using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.Authentication;

namespace Application.Features.Users.Requests.Commands;

public class UserUpdateCommandRequest : IRequest<CommonResponse<int>>
{
    public required UserDto Userdto { get; set; }
}
