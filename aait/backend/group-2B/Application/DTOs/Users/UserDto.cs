using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialSync.Application.DTOs.Common;

namespace Application.DTOs.Common
{
    public class UserDto : BaseDto
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Username { get; set; }
        public string? Bio { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set;}

    }
}