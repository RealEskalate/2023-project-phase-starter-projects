using SocialMediaApp.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Users
{
    public class UpdateUserDto: BaseDto, IUserDto
    {
    public string Name { get; set; }
    public string Bio { get; set; }
    public string? email { get; set; }

    }
}