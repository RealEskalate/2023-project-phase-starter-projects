using SocialSync.Application.DTOs.Common;

namespace SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;

public class UpdateCommentInteractionDTO : BaseDto
{
    public string Body { get; set; }
}