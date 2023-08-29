using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SocialMediaApp.Infrastructure.Services
{
    public class BCryptPasswordService : IPasswordService
    {
        public string HashPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        public bool VerifyPassword(string candidatePassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(candidatePassword, hashedPassword);
        }
    }
}
