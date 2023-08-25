using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts.Persistence;

public interface INotificationRepository : IGenericRepository<Notification>
{
    Task<List<Notification>> GetByUserId(int userId);
    Task MarkAsSeen(int id);
}