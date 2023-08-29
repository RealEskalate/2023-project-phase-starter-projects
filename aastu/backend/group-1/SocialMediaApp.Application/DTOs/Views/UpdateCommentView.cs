using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Views
{
    public class UpdateCommentView : CreateCommentView
    {
        public Guid CommentId { get; set; }
    }
}
