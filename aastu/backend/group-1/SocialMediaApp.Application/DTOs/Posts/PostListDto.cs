using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Common;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Posts
{
    public class PostListDto : BaseDto
    {
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public List<String>? HashTag { get; set; }
        public int Likes { get; set; }
        public List<string> Comments { get; set; }

    }
}
