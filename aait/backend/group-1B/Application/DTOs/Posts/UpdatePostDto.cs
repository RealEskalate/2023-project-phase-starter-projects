using Application.DTOs.Common;

namespace Application.DTOs.Posts;

public class UpdatePostDto : BaseDto, IPostDto
{
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}