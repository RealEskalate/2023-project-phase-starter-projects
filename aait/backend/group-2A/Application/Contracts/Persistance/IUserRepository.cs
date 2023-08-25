using Domain.Entities;

namespace Application.Contracts.Persistance;

public interface IUserRepository : IGenericRepository<User>{

    public Task<User> GetUserByEmail(string email);
    public Task<User> GetUserByUserName(string email);
    
    public Task<List<User>> SearchByUserName(string email);
    public Task<List<User>> SearchByFullName(string email);
    public Task<List<Notification>> GetNotification(int Id);

}