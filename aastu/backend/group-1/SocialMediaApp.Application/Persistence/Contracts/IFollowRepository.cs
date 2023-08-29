using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Application.Persistence.Contracts;

public interface IFollowRepository: IGenericRepository<Follow>
{
    Task<List<Follow>> GetFollowersAsync(Guid userId);
    Task<List<Follow>> GetFollowingsAsync(Guid userId);
    Task<bool> IsAlreadyFollowing(Guid current, Guid toBeFollowed);
}
