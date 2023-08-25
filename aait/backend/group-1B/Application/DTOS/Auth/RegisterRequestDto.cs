using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.Auth
{
    public class RegisterRequestDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Bio { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
