
namespace Application.DTO.CommentDTO.DTO
{
    public class CommentCreateDTO : IBaseCommentDTO
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}