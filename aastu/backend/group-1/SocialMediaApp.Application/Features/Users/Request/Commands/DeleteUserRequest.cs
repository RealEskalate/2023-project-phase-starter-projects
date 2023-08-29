using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SocialMediaApp.Application.Features.Users.Request.Commands
{
    public class DeleteUserCommandRequest:IRequest<Unit>
    {
        public Guid Id { get; set; }   
    }
}