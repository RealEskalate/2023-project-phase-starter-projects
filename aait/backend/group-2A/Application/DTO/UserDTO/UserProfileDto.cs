using Application.DTO.Common;

namespace Application.DTO.UserDTO;

public class UserProfileDTO : BaseDto
{

    public required string FullName { get; set; }
    public required string UserName { get; set; }
    public string Bio { get; set; } = "";
    public int FollowerCount{ get; set; } = 0;
    public int FolloweeCount{ get; set; } = 0;
    public int PostCount{ get; set; } = 0;
}