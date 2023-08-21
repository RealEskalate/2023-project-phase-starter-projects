namespace SocialSync.Application.Contracts.Persistence; 

public interface IGenericRepository<T>
{
    public Task<T> Create(T entity);
    public Task<T> GetById(int id);
    public Task<bool> IdExists(int id);
}
