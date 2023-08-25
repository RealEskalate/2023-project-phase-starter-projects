using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.CommentReactionDTOS.DTO
{
    public class CommentReactionCreateDTO
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }
    }
}
