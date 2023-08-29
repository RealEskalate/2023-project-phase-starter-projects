using Application.Contracts.Persistence;
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

            mockUow.Setup(r => r.PostRepository).Returns(mockPostRepo.Object);
            // mockUow.Setup(r => r.TagRepository).Returns(mockTagRepo.Object);
            // mockUow.Setup(r => r.PostTagRepository).Returns(mockPostTagRepo.Object);


            return mockUow;
        }
    }
}
