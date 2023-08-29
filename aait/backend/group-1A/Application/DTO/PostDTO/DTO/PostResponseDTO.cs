using Application.DTO.CommentDTO.DTO;

namespace Application.DTO.PostDTO.DTO
{
    public class PostResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int UserId {get ; set ;}
        public List<CommentResponseDTO> Comments { get; set; } = new List<CommentResponseDTO> ();

        public int Like { get; set; }

        public int Dislike { get; set; }
    }
}
