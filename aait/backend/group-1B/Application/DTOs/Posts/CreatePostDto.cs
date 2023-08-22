namespace Application.DTOs.Posts;

public class CreatePostDto : IPostDto
{
    public int UserId { set; get; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}