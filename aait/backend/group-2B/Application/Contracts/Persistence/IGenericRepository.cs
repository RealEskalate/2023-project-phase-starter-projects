namespace SocialSync.Application.Contracts.Persistence;


public interface IGenericRepository<T> {
  Task<T> GetAsync(int id);
  Task<T> GetAsync();
  Task<T> AddAsync();
  Task UpdateAsync(T enity);
  Task DeleteAsync(T enity);
}
