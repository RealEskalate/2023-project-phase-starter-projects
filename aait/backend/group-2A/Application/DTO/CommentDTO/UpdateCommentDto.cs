using Application.DTO.Common;

namespace Application.DTO.CommentDTO;

public class UpdateCommentDto : BaseDto, ICommentDto
{
    public string Content { get; set; }
    public int UserId { get; set; }
}