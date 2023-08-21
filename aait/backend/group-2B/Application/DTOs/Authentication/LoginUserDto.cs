namespace SocialSync.Application.DTOs.Authentication;

public class LoginUserDto
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
