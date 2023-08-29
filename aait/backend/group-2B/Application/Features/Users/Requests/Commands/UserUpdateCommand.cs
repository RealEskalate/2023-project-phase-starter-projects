
using Application.DTOs.Common;
using MediatR;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Requests.Commands
{
    public class UserUpdateCommand : IRequest<CommonResponse<int>>
    {
        public required UserDto Userdto {get;set;}
    }
}