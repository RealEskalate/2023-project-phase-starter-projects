using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialMediaApp.Application.Persistence.Contracts.Infrastructure;

namespace SocialMediaApp.Infrastructure.Authentication
{
    public class JwtTokenValidation : IJwtTokenValidation
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenValidation(IOptions<JwtSettings> jwtOptions)
        {
            _jwtSettings = jwtOptions.Value;
        }

        public Guid ExtractUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            Console.WriteLine(jwtToken);

            // Find the claim with the user ID
            var userIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "sub");

            if (userIdClaim != null)
            {
                return Guid.Parse(userIdClaim.Value);
            }

            // Return null if the user ID claim is not found
            return Guid.Empty;
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _jwtSettings.Issuer,

                // Validate the token audience
                ValidateAudience = true,
                ValidAudience = _jwtSettings.Audience,

                // Validate the token expiry
                ValidateLifetime = true,

                // Validate the token signing key
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),

                // Set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                // Validate the token
                SecurityToken validatedToken;
                tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
                Console.WriteLine("The token is Valid");
                return true; // Token is valid
            }
            catch (Exception)
            {
                Console.WriteLine("The token is InValid");
                return false; // Token is invalid
            }
        }
    }
}