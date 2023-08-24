using Application.DTO.Common;

namespace Application.DTO.UserDTO;

public class UserDto : BaseDto
{

    public required string FullName { get; set; }
    public required string UserName { get; set; }
}