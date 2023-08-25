using Moq;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.Tests.Mocks;


public class MockUnitOfWork {
  public static Mock<IUnitOfWork> GetMockUnitOfWork() {
    var mockUnitOfWork = new Mock<IUnitOfWork>();

    var mockUserRepository = MockUserRepository.GetUserRepository();

    mockUnitOfWork.Setup(uow => uow.UserRepository).Returns(mockUserRepository.Object);
    mockUnitOfWork.Setup(uow => uow.SaveAsync()).ReturnsAsync(1);

    return mockUnitOfWork;
  }
}
