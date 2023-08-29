using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Authentication
{
    public record RegisterRequest(

         string Email,
         string Password,
         string Name );

    
}
