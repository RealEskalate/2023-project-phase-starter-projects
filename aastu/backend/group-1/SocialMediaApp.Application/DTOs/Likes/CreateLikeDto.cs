using SocialMediaApp.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Likes
{
    public class CreateLikeDto:ILikeDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }

       
    }
}
