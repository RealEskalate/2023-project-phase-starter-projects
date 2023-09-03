using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO.UserDTO.DTO
{
    public class UpdatePasswordDTO
    {
        public required string  OldPassword {set; get;}
        public required string NewPassword {set; get;}
        public required string ConfirmPassword {set; get;}
    }
}