using Application.DTOs.Common;

namespace Application.DTOs.PostLikes;

public class PostLikeContentDto : BaseDto
{
    public int UserId { get; set; }
    public int PostId { get; set; }
}