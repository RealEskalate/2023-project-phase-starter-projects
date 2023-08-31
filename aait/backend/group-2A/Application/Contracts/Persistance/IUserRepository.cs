using Domain.Entities;

namespace Application.Contracts.Persistance;

public interface IUserRepository : IGenericRepository<User>{

    public Task<User> GetUserByEmail(string email);
    public Task<User> GetUserByUserName(string email);
    
    public Task<List<User>> Search(string email, int pageNumber=0, int pageSize = 10);

}