using SocialSync.Domain.Entities;
using SocialSync.Application.DTOs.Common;

namespace SocialSync.Application.DTOs.InteractionDTOs;

public class InteractionDto : BaseDto
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public InteractionType Type { get; set; }
    public string? Body { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }
}