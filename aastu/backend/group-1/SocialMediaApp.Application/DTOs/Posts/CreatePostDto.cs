using SocialMediaApp.Application.DTOs.Posts.Validators;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Posts
{
    public class CreatePostDto: IPostDto
    {
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public List<String>? HashTag { get; set; }

    }
}
