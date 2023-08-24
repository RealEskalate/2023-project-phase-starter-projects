using SocialSync.Application.DTOs.Common;

namespace SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;

public class UpdateCommentInteractionDto : BaseDto
{
    public string Body { get; set; }
}