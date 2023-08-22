namespace Application.DTOs.Comments;

public class CreateCommentDto : ICommentDto
{
    public int UserId { set; get; }
    public int PostId { set; get; }
    public string Content { set; get; } = string.Empty;
}