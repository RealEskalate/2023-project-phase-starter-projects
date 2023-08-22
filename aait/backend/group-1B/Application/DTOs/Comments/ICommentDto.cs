namespace Application.DTOs.Comments;

public interface ICommentDto
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; }
}