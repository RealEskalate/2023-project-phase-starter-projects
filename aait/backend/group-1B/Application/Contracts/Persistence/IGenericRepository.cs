namespace Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<T?> Get(int id);
    Task<List<T>> GetAll();
    Task<bool> Exists(int id);
    Task<T> Add(T item);
    Task<T> Update(T item);
    Task Delete(T item);
}