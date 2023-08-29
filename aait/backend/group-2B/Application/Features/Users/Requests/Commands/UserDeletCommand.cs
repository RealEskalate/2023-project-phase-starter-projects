
using Application.DTOs.Users;
using MediatR;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Requests.Commands
{
    public class UserDeleteCommand : IRequest<CommonResponse<int>> 
        {

        public required UserDeletDto UserdleteDto {get;set;}
        
    }
}