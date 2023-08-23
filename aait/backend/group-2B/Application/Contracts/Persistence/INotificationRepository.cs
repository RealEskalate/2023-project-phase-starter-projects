using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Persistence;

public interface INotificationRepository : IGenericRepository<Notification>
{
    public Task<List<Notification>> GetAll(int userId);
}