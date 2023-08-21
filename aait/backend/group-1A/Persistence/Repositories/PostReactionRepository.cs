
using Application.Contracts;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class PostReactionRepository : GenericReactionRepository<PostReaction>, IPostReaction
    {
       
    }
}
