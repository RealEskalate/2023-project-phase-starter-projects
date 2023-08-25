using Moq;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.Tests.Mocks;


public class MockUnitOfWork {
  public static Mock<IUnitOfWork> GetMockUnitOfWork() {
    var unitOfWork = new Mock<IUnitOfWork>();

    var mockUserRepository = MockUserRepository.GetUserRepository();

    unitOfWork.Setup(uow => uow.UserRepository).Returns(mockUserRepository.Object);

    return unitOfWork;
  }
}
