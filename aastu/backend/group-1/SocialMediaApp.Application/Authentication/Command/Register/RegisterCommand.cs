using MediatR;
using SocialMediaApp.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Authentication.Command.Register
{
    public record RegisterCommand(
        string Name,
        string Email,
        string Password): IRequest<AuthenticationResult>;
    
}
