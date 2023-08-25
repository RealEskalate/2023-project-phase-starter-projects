namespace SocialSync.Application.DTOs.Authentication;

public class LoginUserDto : IUserDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
