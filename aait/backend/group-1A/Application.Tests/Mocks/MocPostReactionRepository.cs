using Application.Contracts;
using Domain.Entites;
using Domain.Entities;
using Moq;

namespace Application.Tests.Mocs
{
    public static class MockPostReactionRepository
    {
        public static Mock<IPostReactionRepository> GetPostReactionRepository()
        {
            var PostReactions = new List<PostReaction>
            {
                new PostReaction
                {
                    PostId = 1,
                    
                },
                new PostReaction
                {
                    PostId = 2,
                    Like = true,
                    UserId = 1
                },
                new PostReaction
                {
                    PostId = 2,
                    Like = false,
                    UserId = 1   
                },
            };

        var mockRepo = new Mock<IPostReactionRepository>();
        // var mockUserRepo = MockUserRepository.GetUserRepository();

        mockRepo.Setup(r => r.MakeReaction(It.IsAny<int>(), It.IsAny<PostReaction>()))
        .ReturnsAsync((int id, PostReaction entity) => 
        {
            PostReactions.Add(entity);
            return entity;
        });
        
        return mockRepo;

        }
    }
}