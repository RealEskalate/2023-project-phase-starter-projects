
using Application.DTOs.Users;
using MediatR;

namespace Application.Features.Users.Requests.Commands
{
    public class UserDeleteCommand : IRequest<Unit> 
        {

        public required UserDeletDto UserdleteDto {get;set;}
        
    }
}