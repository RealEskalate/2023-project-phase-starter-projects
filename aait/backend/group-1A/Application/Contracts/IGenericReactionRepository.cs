using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGenericReactionRepository<T>
    {
        public Task<bool> Add(T entity);

        public Task<bool> Delete(int Id,T entity);

        public Task<List<T>> Likes(int Id);

        public Task<List<T>> DisLikes(int Id);

    }
}
