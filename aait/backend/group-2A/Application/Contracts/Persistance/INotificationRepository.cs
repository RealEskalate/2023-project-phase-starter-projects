using Domain.Entities;

namespace Application.Contracts.Persistance;

public interface INotificationRepository{
     Task<List<Notification>> GetNotifications(int id);
     Task<Notification> GetNotification(int notifiactionId);
     Task  AddNotification(Notification notify);
     
     Task MarkAsRead(int id);
}