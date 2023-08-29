using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts;

public interface INotificationRepository : IGenericRepository<Notification>
{
    Task<List<Notification>> GetNotifications(Guid userId);
    Task<Notification> GetNotificationDetails(Guid userId, Guid id);

}
