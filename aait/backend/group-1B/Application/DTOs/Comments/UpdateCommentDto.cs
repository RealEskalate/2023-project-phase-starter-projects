using Application.DTOs.Common;

namespace Application.DTOs.Comments;

public class UpdateCommentDto : BaseDto, ICommentDto
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; } = string.Empty;
}