
using SocialSync.Application.DTOs.Common;

namespace SocialSync.Application.DTOs.PostDtos;

public class GeneralPostDto : BaseDto
{
    public int UserId { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModified { get; set; }

}
