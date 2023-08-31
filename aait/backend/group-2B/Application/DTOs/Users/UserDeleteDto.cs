
using SocialSync.Application.DTOs.Common;

namespace Application.DTOs.Users;

public class UserDeleteDto : BaseDto
{

    public int Owner { get; set; }
}
