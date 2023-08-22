
namespace SocialSync.Application.Dtos.Authentication
{
    public class LoginResponseDto
    {   
        public string Token { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}