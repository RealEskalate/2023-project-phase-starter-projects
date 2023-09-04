using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UserDTO.DTO
{
    public class UserUpdateDTO
    {
        public string? Username { get; set; }

        public string? Email { get; set; }
    
         public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Bio { get; set; }


    }
}
