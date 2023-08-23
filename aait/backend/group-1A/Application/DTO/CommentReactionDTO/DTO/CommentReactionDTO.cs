namespace Application.DTO.CommentReactionDTO.DTO
{
    public class CommentReactionDTO
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }

    }
}