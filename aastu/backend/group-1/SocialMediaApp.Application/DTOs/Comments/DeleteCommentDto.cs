using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Comments
{
    public class DeleteCommentDto
    {
        public Guid UserId { get; set; }

        public Guid Id { get; set; }
    }
}
