using Application.DTO.Common;

namespace Application.DTO.CommentDTO;

public class CommentDto : BaseDto, ICommentDto
{
    public string Content { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}