using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Comments
{
    public class CreateCommentDto : ICommentDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string? Text { get; set; }
    }
}
