using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Tests.Features.UserFeatureTests.Mocks;
using Application.Tests.Mocs;
using Moq;

namespace Application.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();    
            var mockFollowRepository = MockFollowRepository.GetFollowRepository();
            var mockCommentReactionRepository = MockCommentReactionRepository.GetCommentReactionRepository();
            var mockCommentRepository = MockCommentRepository.GetCommentRepository();
            var mockPostRepository = MockPostRepository.GetPostRepository();
            var mockUserRepository = MockUserRepository.GetUserRepository();
            var mockPostReactionRepository = MockPostReactionRepository.GetPostReactionRepository();





            mockUnitOfWork.Setup(
                r => r.FollowRepository)
                .Returns(mockFollowRepository.Object);

             mockUnitOfWork.Setup(
                r => r.CommentReactionRepository)
                .Returns(mockCommentReactionRepository.Object);
            
             mockUnitOfWork.Setup(
                r => r.CommentRepository)
                .Returns(mockCommentRepository.Object);

            mockUnitOfWork.Setup(
                r => r.PostRepository)
                .Returns(mockPostRepository.Object);


            mockUnitOfWork.Setup(
                r => r.UserRepository)
                .Returns(mockUserRepository.Object); 

            mockUnitOfWork.Setup(
                r => r.PostReactionRepository)
                .Returns(mockPostReactionRepository.Object);                
            
            
            mockUnitOfWork.Setup(r => r.Save()).ReturnsAsync(1);
            return mockUnitOfWork;
        }
    }
}