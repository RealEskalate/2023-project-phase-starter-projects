using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Comments
{
    public  interface ICommentDto
    {
        public string? Text { get; set; }

        public Guid UserId { get; set; }
        public Guid PostId { get; set; }

    }
}
