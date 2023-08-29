using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Follows
{
    public interface IFollowDto
    {
    public Guid CurrentUser { get; set; }
    public Guid ToBeFollowed { get; set; }
    }
}