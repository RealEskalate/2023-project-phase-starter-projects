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
<<<<<<< HEAD
        if(userId != null){
            return int.Parse(userId);
        }
        return 0;
=======
        return int.Parse(userId);
>>>>>>> df672ccb (fix(AAiT-backend-2b): update post endpoints with authorizaton feature)
    }
}
