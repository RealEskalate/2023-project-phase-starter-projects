using SocialMediaApp.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Posts
{
    public class UpdatePostDto:BaseDto, IPostDto

    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public List<String>? HashTag { get; set; }
        public Guid UserId { get; set; }

      
    }
}
