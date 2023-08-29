using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Views
{
    public class RegisterUserView
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string? email { get; set; }
    }
}
