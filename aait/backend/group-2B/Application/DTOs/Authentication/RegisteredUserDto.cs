using SocialSync.Domain.Entities;

namespace SocialSync.Application.DTOs.Authentication;

public class RegisteredUserDto
{
    public User User { get; set; } = null!;
    public string Token { get; set; } = null!;
}
