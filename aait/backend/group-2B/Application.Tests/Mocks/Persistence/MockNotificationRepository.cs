using Moq;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Tests.Mocks
{
    public class MockNotificationRepository
    {
        public static Mock<INotificationRepository> GetNotificationRepository()
        {
            var notifications = new List<Notification>
            {
                new Notification
                {
                    Id = 1,
                    SenderId = 2,
                    RecepientId = 3,
                    PostId = 2,
                    NotificationType = NotificationType.Like,
                    CreatedAt = DateTime.UtcNow.Date,
                    LastModified = DateTime.UtcNow.Date
                },
                new Notification
                {
                    Id = 2,
                    SenderId = 1,
                    RecepientId = 2,
                    PostId = 1,
                    NotificationType = NotificationType.Like,
                    CreatedAt = DateTime.UtcNow.Date,
                    LastModified = DateTime.UtcNow.Date
                },
                new Notification
                {
                    Id = 3,
                    SenderId = 3,
                    RecepientId = 1,
                    PostId = null,
                    NotificationType = NotificationType.Follow,
                    CreatedAt = DateTime.UtcNow.Date,
                    LastModified = DateTime.UtcNow.Date
                },
                // ... (other notifications)
            };

            var notificationRepo = new Mock<INotificationRepository>();

            notificationRepo.Setup(repo => repo.AddAsync(It.IsAny<Notification>()))
                .ReturnsAsync((Notification notification) =>
                {
                    notification.Id = notifications.Count + 1;
                    notifications.Add(notification);
                    return notification;
                });

            notificationRepo.Setup(repo => repo.GetAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => notifications.FirstOrDefault(n => n.Id == id));

            notificationRepo.Setup(repo => repo.GetAll(It.IsAny<int>()))
                .ReturnsAsync((int userId) => notifications.Where(n => n.RecepientId == userId).ToList());

            notificationRepo.Setup(repo => repo.DeleteAsync(It.IsAny<Notification>())).Callback((Notification notification) => 
            {
                var notificationToDelete = notifications.FirstOrDefault(n => n.Id == notification.Id);
                if (notificationToDelete != null)
                {
                    notifications.Remove(notificationToDelete);
                }
            });
            

            return notificationRepo;
        }
    }
}
