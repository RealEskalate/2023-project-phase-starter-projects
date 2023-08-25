using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO.CommentDTO.DTO
{
    public class CommentUpdateDTO : IBaseCommentDTO
    {
        public string Content { get ; set; }
    }
}