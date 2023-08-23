using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.CommentReactionDTO.DTO
{
    public class CommentReactionResponseDTO
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }
    }
}
