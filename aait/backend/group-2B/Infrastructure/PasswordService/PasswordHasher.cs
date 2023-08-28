using System.Security.Cryptography;
using SocialSync.Application.Contracts.Infrastructure;

namespace SocialSync.Infrastructure.PasswordService;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 128 / 8;
    private const int KeySize = 256 / 8;
    private const int Iterations = 10000;
    private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
    private static char Delimiter = ';';

    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            _hashAlgorithmName,
            KeySize
        );

        return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var elements = hashedPassword.Split(Delimiter);
        var salt = Convert.FromBase64String(elements[0]);
        var password = Convert.FromBase64String(elements[1]);

        var hashProvidedPassword = Rfc2898DeriveBytes.Pbkdf2(
            providedPassword,
            salt,
            Iterations,
            _hashAlgorithmName,
            KeySize
        );

        return CryptographicOperations.FixedTimeEquals(password, hashProvidedPassword);
    }
}
