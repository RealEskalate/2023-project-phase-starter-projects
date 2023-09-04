using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts.Infrastructure
{
        public interface IJwtTokenValidation
        {
            bool ValidateToken(string token);
            Guid ExtractUserIdFromToken(string token);
        }
    
}
