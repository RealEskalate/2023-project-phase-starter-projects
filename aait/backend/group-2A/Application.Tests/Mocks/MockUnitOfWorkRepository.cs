using Application.Contracts.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks
{
    public class MockUnitOfWorkRepository
    {
        public static int Changes = 0;
        public static Mock<IUnitOfWork> GetMockUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.SetupAllProperties();

            var mockCommentRepository = MockCommentRepository.GetCommentRepository();
            var mockFollowRepository = MockFollowRepository.GetFollowRepository();
            var mockLikeRepository = MockLikeRepository.GetLikeRepository();
            var mockPostRepository = MockPostRepository.GetPostRepository();
            var mockNotificationRepository = MockNotificationRepository.GetNotificationRepository();
            var mockUserRepository = MockUserRepository.GetUserRepository();
            

            mockUnitOfWork.Setup(uow => uow.commentRepository).Returns(mockCommentRepository.Object);
            mockUnitOfWork.Setup(uow => uow.postRepository).Returns(mockPostRepository.Object);
            mockUnitOfWork.Setup(uow => uow.followRepository).Returns(mockFollowRepository.Object);
            mockUnitOfWork.Setup(uow => uow.likeRepository).Returns(mockLikeRepository.Object);
            mockUnitOfWork.Setup(uow => uow.notificationRepository).Returns(mockNotificationRepository.Object);
            mockUnitOfWork.Setup(uow => uow.userRepository).Returns(mockUserRepository.Object);

            mockUnitOfWork.Setup(uow => uow.Save()).ReturnsAsync(() => {
                int temp = Changes;
                Changes = 0;
                return temp;
            });

            return mockUnitOfWork;
        }
    }
}
