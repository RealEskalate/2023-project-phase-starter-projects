using SocialSync.Application.DTOs.Common;

namespace SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;

public class UpdateCommentInteractionDto : BaseDto
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Body { get; set; }
}