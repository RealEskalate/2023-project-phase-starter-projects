using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Application.DTOs.Common;
using SocialMediaApp.Application.DTOs.Follows;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Application.DTOs.Users;

public class UserDto: BaseDto
{
    public string Name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public List<FollowDto> Followers { get; set; }
    public List<PostDto> Post { get; set; }
    public List<NotificationDto> Notifications { get; set; }
    public string Bio { get; set; }
}
