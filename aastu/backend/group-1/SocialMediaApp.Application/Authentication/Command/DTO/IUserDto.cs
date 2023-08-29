using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SocialMediaApp.Authentication.Command.DTO
{
    public interface IUserDto
    {
    public string? Name { get; set; }
    public string? email { get; set; }
    public string? Bio { get; set; }
    }
}