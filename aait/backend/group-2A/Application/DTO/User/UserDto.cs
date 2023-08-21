using Application.DTO.Common;

namespace Application.DTO.User;

public class UserDto : BaseDto
{
    public required string UserName { get; set; }
}