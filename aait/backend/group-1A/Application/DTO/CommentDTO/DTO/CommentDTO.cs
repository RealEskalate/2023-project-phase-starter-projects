namespace Application.DTOs.CommentDTO.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        // Add other properties as needed
    }
}