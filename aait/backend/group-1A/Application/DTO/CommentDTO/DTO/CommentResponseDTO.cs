
namespace Application.DTO.CommentDTO.DTO
{
    public class CommentResponseDTO
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public int UserId { get; set; }
    }
}
