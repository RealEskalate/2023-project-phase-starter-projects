using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UserDTO
{
    public class CreateUserDTO : IUserDTO
    {
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Bio { get; set; } = "";
    }
}
