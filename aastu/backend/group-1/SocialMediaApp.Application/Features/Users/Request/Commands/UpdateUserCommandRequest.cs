using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SocialMediaApp.Application.DTOs.Users;

namespace SocialMediaApp.Application.Features.Users.Request.Commands
{
    public class UpdateUserCommandRequest:IRequest<Unit>
    {
        public UpdateUserDto UpdateUserDto { get; set; } = null!;
        
    }
}