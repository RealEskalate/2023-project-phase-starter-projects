using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.CommentReactionDTO.DTO;

namespace Application.DTO.CommentDTO.DTO
{
    public class CommentResponseDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public List<CommentReactionResponseDTO> Reactions { get; set; }

        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}
