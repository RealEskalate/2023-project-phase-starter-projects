using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts
{
    public interface IPasswordService
    {
        string HashPassword(string plainPassword);
        bool VerifyPassword(string candidatePassword, string hashedPassword);
    }
}
