using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.Common;

namespace Application.DTO.UserDTO
{
    public class UpdateUserDTO : BaseDto, IUserDTO
    {

        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
    }
}
