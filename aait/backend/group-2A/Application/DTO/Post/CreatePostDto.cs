using Domain.Entities;

namespace Application.DTO.Post;

public class CreatePostDto : IPostDto
{
    public required int UserId { get; set; }
    public required string Content { get; set; }
    public List<string> Tags{ get; set; } = new List<string>();
}