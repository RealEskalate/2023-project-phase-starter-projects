using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UserDTO.DTO
{
    public class UserCreateDTO : IBaseUserDTO
    {
        public int Id { get; set; }
        public string? Username { get ; set ; }
        public string? Email { get ; set ; }
        public string? Password { get ; set ; }
    }
}
