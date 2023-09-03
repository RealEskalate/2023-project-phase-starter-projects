using Application.Contracts.Persistence;
using Application.Tests.Mocks.Comment;
using Application.Tests.Mocks.PostMock;
using Moq;

namespace SocialSync.Application.Tests.Mocks.PostMock.PostMock
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();

            var mockPostRepo = MockPostRepository.GetPostRepository();
            // var mockTagRepo = MockTagRepository.GetTagRepository();
            var mockPostTagRepo = MockPostTagRepository.GetPostTagRepository();

            var mockCommentRepo = MockCommentRepository.GetCommentRepository();

            var mockNotificationRepo = MockNotificationRepository.GetNotificationRepository();

            mockUow.Setup(r => r.PostRepository).Returns(mockPostRepo.Object);
            mockUow.Setup(r => r.CommentRepository).Returns(mockCommentRepo.Object);
            mockUow.Setup(r => r.NotificationRepository).Returns(mockNotificationRepo.Object);
            // mockUow.Setup(r => r.TagRepository).Returns(mockTagRepo.Object);
            // mockUow.Setup(r => r.PostTagRepository).Returns(mockPostTagRepo.Object);


            return mockUow;
        }
    }
}
