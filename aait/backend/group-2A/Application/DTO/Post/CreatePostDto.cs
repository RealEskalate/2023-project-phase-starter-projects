using Domain.Entities;

namespace Application.DTO.Post;

public class CreatePostDto : IPostDto
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public int LikeCount{ get; } = 0;
    public int CommentCount{ get; } = 0;
    public List<Tag>? Tags{ get; set; } = new List<Tag>();
}