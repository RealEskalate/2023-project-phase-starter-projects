

namespace Application.Contracts.Persistance;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<List<T>> GetAll();
    Task<T> Add(T entity);
    Task<bool> Exists(int id);
    Task Update(T entity);
    Task Delete(T entity);
    
}