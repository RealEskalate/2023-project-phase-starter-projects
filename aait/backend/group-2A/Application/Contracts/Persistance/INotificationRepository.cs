using Domain.Entities;

namespace Application.Contracts.Persistance;

public interface INotificationRepository{
     Task<List<Notification>> GetNotifications(int userid, int pageNumber=0, int pageSize = 10);
     Task<Notification> GetNotification(int notifiactionId);
     Task  AddNotification(Notification notify);
     
     Task MarkAsRead(int id);
}