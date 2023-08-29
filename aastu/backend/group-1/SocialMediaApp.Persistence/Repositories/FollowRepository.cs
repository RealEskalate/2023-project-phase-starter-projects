using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Persistence.Repositories;

public class FollowRepository : GenericRepository<Follow>, IFollowRepository
{
    private readonly SocialMediaAppDbContext _context;

    public FollowRepository(SocialMediaAppDbContext dbContext):base(dbContext)
    {
        _context = dbContext;
    }


    public async Task<List<Follow>>  GetFollowersAsync(Guid userId)
    {
        var followers  = await _context.Follows.Where(u => u.ToBeFollowed == userId).ToListAsync() ?? throw new NotFoundException("${userId}", userId);
        return followers;
        
        }

    public async Task<List<Follow>> GetFollowingsAsync(Guid userId)
    {
        var followings = await _context.Follows.Where(u => u.CurrentUser == userId).ToListAsync();
        
        return followings;

    }

    public async Task<bool> IsAlreadyFollowing(Guid current, Guid toBeFollowed)
    {
        var followExists = await _context.Follows.Where(f=>f.CurrentUser == current && f.ToBeFollowed==toBeFollowed).ToListAsync();
        Console.WriteLine(followExists.Count());
        return followExists.IsNullOrEmpty();
    }
}
