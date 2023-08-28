using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Users
{
    public class UpdateUserDto

    {
        public int Id { get; set; }

        public string FirstName { get; set; }
    
        public string LastName { get; set; }
    
        public string Bio { get; set; }
    }
}
