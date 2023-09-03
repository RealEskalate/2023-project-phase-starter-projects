using Application.Contracts;
using Domain.Entites;
using Domain.Entities;
using Moq;

namespace Application.Tests.Mocs
{
    public static class MockCommentReactionRepository
    {
        public static Mock<ICommentReactionRepository> GetCommentReactionRepository()
        {
            var CommentReactions = new List<CommentReaction>
            {
                new CommentReaction
                {
                    CommentId = 1,
                    
                },
                new CommentReaction
                {
                    CommentId = 2,
                    Like = true,
                    UserId = 1
                },
                new CommentReaction
                {
                    CommentId = 2,
                    Like = false,
                    UserId = 1   
                },
            };

        var mockRepo = new Mock<ICommentReactionRepository>();
        // var mockUserRepo = MockUserRepository.GetUserRepository();

        mockRepo.Setup(r => r.MakeReaction(It.IsAny<int>(), It.IsAny<CommentReaction>()))
        .ReturnsAsync((int id, CommentReaction entity) => 
        {
            CommentReactions.Add(entity);
            return entity;
        });
        
        return mockRepo;

        }
    }
}