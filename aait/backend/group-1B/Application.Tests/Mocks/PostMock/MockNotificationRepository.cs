using Application.Contracts.Persistence;
using Moq;
using Domain.Entities;

namespace Application.Tests.Mocks.PostMock;

public class MockNotificationRepository
{

    public static Mock<INotificationRepository> GetNotificationRepository(){

        var notifications = new List<Notification>
        {
            new Notification
            {
                Id = 1,
                UserId = 1,
                Message = "This is a Test Notification from User 1",
                Seen = false
            },
            new Notification
            {
                Id = 2,
                UserId = 2,
                Message = "This is a Test Notification from User 2",
                Seen = true
            },
            new Notification
            {
                Id = 3,
                UserId = 1,
                Message = "This is a Test Notification from User 3",
                Seen = false
            }
        };

        var mockRepo = new Mock<INotificationRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(notifications);

        mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int id) =>{
            var notification = notifications.FirstOrDefault(x=> x.Id == id);
            return notification;
        });

        mockRepo.Setup(r => r.Add(It.IsAny<Notification>())).ReturnsAsync((Notification notification) => 
        {
            notifications.Add(notification);
            return notification;
        });
        
        mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>{
            var notification = notifications.FirstOrDefault(x=> x.Id == id);
            return notification != null;
        });

        mockRepo.Setup(r => r.GetByUserId(It.IsAny<int>())).ReturnsAsync((int userId) => {
            var notification = notifications.Where(x=> x.UserId == userId);
            return notification.ToList();
        });
        return mockRepo;


    }
    
}