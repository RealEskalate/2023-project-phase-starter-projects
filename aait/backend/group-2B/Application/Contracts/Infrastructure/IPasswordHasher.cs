namespace SocialSync.Application.Contracts.Infrastructure;

public interface IPasswordHasher
{
    public string HashPassword(string password);
    public bool VerifyPassword(string hashedPassword, string inputPassword);
}
