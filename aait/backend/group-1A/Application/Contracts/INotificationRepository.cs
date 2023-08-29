using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entites;

namespace Application.Contracts
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<Notification> GetSingle(int id);

        Task<bool> MarkAsRead(int id, int userId);

        Task<bool> MarkAllAsRead(int UserId);

        Task<bool> Exists(int id);

        Task<List<Notification>> GetAllUnread(int userId);

        Task<List<Notification>> GetAll(int userId);
    }
}