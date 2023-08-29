using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Users
{
    public interface IUserDto
    {
    public string? Name { get; set; }
    public string? email { get; set; }
    public string? Bio { get; set; }
    }
}