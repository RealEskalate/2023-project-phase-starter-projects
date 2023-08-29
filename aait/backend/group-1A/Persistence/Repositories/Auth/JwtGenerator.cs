using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SocialSync.Application.Contracts;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistence.Repositories.Auth;

public class JwtGenerator : IJwtGenerator
{
    

    public Task<string> CreateTokenAsync(User user)
    {

        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("4A7F9D8C3E6B025F1A4D763CACB2E832A6E9D6F591B6322A54CE33D25773E45B"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var secuirtyToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: signingCredentials,
            issuer: "localhost", 
            audience: "localhost"
        );

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(secuirtyToken));
    }
}