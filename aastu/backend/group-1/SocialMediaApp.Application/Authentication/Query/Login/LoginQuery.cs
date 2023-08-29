using MediatR;
using SocialMediaApp.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Authentication.Query.Login
{
    public record LoginQuary(
        string Email,
        string Password) : IRequest<AuthenticationResult>;

}
