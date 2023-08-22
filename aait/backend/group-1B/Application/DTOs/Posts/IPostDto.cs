namespace Application.DTOs.Posts;

public interface IPostDto
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}