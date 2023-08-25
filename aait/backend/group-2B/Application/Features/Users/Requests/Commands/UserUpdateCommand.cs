using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Common;
using MediatR;

namespace Application.Features.Users.Requests.Commands
{
    public class UserUpdateCommand : IRequest<Unit>
    {
        public UserDto Userdto {get;set;}
    }
}