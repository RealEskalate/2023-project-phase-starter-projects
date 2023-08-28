using Domain.Entities;

namespace Application.Contracts.Persistance;

public interface INotificationRepository{
     Task<List<Notification>> GetNotifications(int id);
     Task  AddNotification(Notification notify);
}