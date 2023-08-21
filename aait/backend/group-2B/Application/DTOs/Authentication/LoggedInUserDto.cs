using SocialSync.Domain.Entities;

namespace SocialSync.Application.DTOs.Authentication;

public class LoggedInUserDto
{
    public User User { get; set; } = null!;
    public string Token { get; set; } = null!;
}
