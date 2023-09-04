using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UserDTO.DTO
{
    public class UserResponseDTO : UserUpdateDTO
    {
        public int Id { get; set; }
        public string? Username { get ; set ; }
        public string? Email { get ; set ; }
    }
}