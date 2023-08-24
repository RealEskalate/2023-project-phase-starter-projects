using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO.CommentDTO.DTO
{
    public class CommentCreateDTO : IBaseCommentDTO
    {
        public string Content { get ; set ; }
    }
}