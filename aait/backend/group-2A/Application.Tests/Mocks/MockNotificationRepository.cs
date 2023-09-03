using Application.Contracts.Persistance;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Tests.Mocks
{
    public static class MockNotificationRepository
    {
        public static Mock<INotificationRepository> GetNotificationRepository()
        {
            var mockNotifications = new List<Notification>
            {
                new Notification { Id = 1, UserId = 1,NotifierId = 1, Message = "Notification 1", IsRead = false },
                new Notification { Id = 2, UserId = 1,NotifierId = 2, Message = "Notification 2", IsRead = true },
                new Notification { Id = 3, UserId = 2,NotifierId = 3, Message = "Notification 3", IsRead = false }
            };

            var mockRepository = new Mock<INotificationRepository>();

            mockRepository.Setup(repo => repo.GetNotifications(It.IsAny<int>(),It.IsAny<int>(),It.IsAny<int>()))
                .ReturnsAsync((int id,int pageNumber,int pageSize) => mockNotifications.Where(n => n.UserId == id).ToList());

            mockRepository.Setup(repo => repo.GetNotification(It.IsAny<int>()))
                .ReturnsAsync((int id) => mockNotifications.FirstOrDefault(n => n.Id == id));

            mockRepository.Setup(repo => repo.AddNotification(It.IsAny<Notification>()))
                .Returns(Task.CompletedTask)
                .Callback((Notification notify) =>
                {
                    notify.Id = mockNotifications.Max(n => n.Id) + 1;
                    mockNotifications.Add(notify);
                });

            mockRepository.Setup(repo => repo.MarkAsRead(It.IsAny<int>()))
                .Returns(Task.CompletedTask)
                .Callback((int id) =>
                {
                    var notification = mockNotifications.FirstOrDefault(n => n.Id == id);
                    if (notification != null)
                    {
                        notification.IsRead = true;
                    }
                });

            return mockRepository;
        }
    }
}
