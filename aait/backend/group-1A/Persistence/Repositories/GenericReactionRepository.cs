using Application.Contracts;

namespace Persistence.Repositories
{
    public class GenericReactionRepository<T> : IGenericReactionRepository<T> where T : class
    {

        public Task<bool> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id, T entity)
        {
            throw new NotImplementedException();
        }

        // Get dislikes given for a post by PostId
        public Task<List<T>> DisLikes(int PostId)
        {

            throw new NotImplementedException();
        }

        // Get likes given for a post by PostId
        public Task<List<T>> Likes(int PostId)
        {
            throw new NotImplementedException();
        }
    }
}
