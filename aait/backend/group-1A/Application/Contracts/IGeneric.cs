using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGeneric<T>
    {
        public Task<T> Get(int id);

        public Task<List<T>> GetAll();

        public Task<T> Add(T entity);

        public Task<int> Delete(int id);

        public Task<T> Update(int id, T entity);   

        public Task<bool> Exists(int id);

    }
}
