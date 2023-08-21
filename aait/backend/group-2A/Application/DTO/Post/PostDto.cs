using Application.DTO.Common;
using Domain.Entities;

namespace Application.DTO.Post;

public class PostDto : BaseDto, IPostDto
{
    public int UserId { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int LikeCount { get; set; } 
    public int CommentCount { get; set; }
    public List<Tag> Tags{ get; set; }
}