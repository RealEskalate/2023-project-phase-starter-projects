using Application.DTOs.Common;
using Domain.Common;

namespace Application.DTOs.Comments;

public class CommentContentDto : BaseDto, ICommentDto
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; } = string.Empty;
}