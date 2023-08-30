
using Application.DTOs.Common;
using MediatR;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Requests.Commands;

public class UserUpdateCommandRequest: IRequest<CommonResponse<int>>
{
    public required UserDto Userdto { get; set; }
}
