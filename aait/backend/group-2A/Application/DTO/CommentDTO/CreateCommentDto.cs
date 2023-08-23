namespace Application.DTO.CommentDTO;

public class CreateCommentDto : ICommentDto
{
    public string Content { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
}