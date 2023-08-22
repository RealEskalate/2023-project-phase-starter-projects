using Application.Contracts;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public Task<Post> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> Update(int id, Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
