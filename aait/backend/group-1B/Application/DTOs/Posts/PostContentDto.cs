using System.Runtime.Intrinsics.Arm;
using Application.DTOs.Common;

namespace Application.DTOs.Posts;

public class PostContentDto : BaseDto, IPostDto
{
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int NumberOfLikes { get; set; }
    public int NumberOfComments { get; set; }
}