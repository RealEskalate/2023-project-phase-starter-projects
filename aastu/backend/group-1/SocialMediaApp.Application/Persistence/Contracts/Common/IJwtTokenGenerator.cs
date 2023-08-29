using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts.Common
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
