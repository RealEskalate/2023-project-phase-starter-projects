using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Application.DTOs.Common;

namespace SocialMediaApp.Application.DTOs.Follows;

public class FollowDto:IFollowDto
{
    public Guid CurrentUser { get; set; }
    public Guid ToBeFollowed { get; set; }
}
