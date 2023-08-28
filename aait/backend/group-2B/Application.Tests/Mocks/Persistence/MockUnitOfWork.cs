using Moq;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.Tests.Mocks;


public class MockUnitOfWork {
  public static Mock<IUnitOfWork> GetMockUnitOfWork() {
    var unitOfWork = new Mock<IUnitOfWork>();

    var mockUserRepository = MockUserRepository.GetMockUserRepository();
    var mockInteractionRepository = MockInteractionRepository.GetMockInteractionRepository();

    unitOfWork.Setup(uow => uow.UserRepository).Returns(mockUserRepository.Object);
    unitOfWork.Setup(uow => uow.SaveAsync()).ReturnsAsync(1);
    unitOfWork.Setup(uow => uow.InteractionRepository).Returns(mockInteractionRepository.Object);
    return unitOfWork;
  }
}
