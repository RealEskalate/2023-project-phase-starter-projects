using Domain.Entities;

namespace Application.Contracts.Persistance;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetUserByIdAsync(int userId);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> AddUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(int userId);

}