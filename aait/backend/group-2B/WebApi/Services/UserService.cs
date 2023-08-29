using System.Security.Claims;
using SocialSync.WebApi.Services.Interfaces;

namespace SocialSync.WebApi.Services;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if(userId != null){
            return int.Parse(userId);
        }
        return 0;

    }
}
