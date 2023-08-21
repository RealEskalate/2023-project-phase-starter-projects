using Application.DTO.Common;

namespace Application.DTO.User;

public class UserProfileDto : BaseDto
{
    public required string FullName { get; set; }
    public required string UserName { get; set; }
    public string Bio { get; set; } = "";
    public int FollowerCount { get; set; }
    public int FollowingCount { get; set; }
    public int PostCount { get; set; }
}