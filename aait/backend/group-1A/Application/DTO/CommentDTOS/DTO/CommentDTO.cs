namespace Application.DTO.CommentDTOS.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public static implicit operator int(CommentDTO v)
        {
            throw new NotImplementedException();
        }
    }
}