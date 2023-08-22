using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGenericRepository<T>
    {
        public Task<List<T>> GetAll();

        public Task<T> Add(T entity);

        public Task<bool> Delete(int id);

        public Task<bool> Exists(int id);

        public Task<List<T>> Likes(int Id);

        public Task<List<T>> DisLikes(int Id);

    }
}
