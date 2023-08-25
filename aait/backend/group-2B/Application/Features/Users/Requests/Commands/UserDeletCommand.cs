using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SocialSync.Application.DTOs.Common;

namespace Application.Features.Users.Requests.Commands
{
    public class UserDeleteCommand : IRequest<Unit> 
        {

        public  BaseDto  UserDleteDto {get;set;}
        
    }
}