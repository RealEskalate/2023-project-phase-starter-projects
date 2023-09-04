using SocialMediaApp.Domain;

namespace SocialMediaApp.Application.Persistence.Contracts;
public interface IUserRepository:IGenericRepository<User>
{
    public User? GetByEmail(string email);
    Task<IReadOnlyList<User>> GetByNameAsync(string name);
    public void AddUser(User user);
    User EditUser(User user);


}
