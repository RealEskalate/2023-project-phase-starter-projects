using Application.Contracts.Persistence;
using Moq;

namespace Application.Tests.Mocks.Comment
{
    public static class MockCommentRepository
    { 
        
        public static Mock<ICommentRepository> GetCommentRepository()
        {
            var comments = new List<Domain.Entities.Comment>
            {
                new Domain.Entities.Comment
                {
                    Id = 1, 
                    UserId = 1,
                    PostId = 1,
                    Content = "This is a Test Comment from User 1",
                },
                new Domain.Entities.Comment
                {
                    Id = 2, 
                    UserId = 2,
                    PostId = 2,
                    Content = "This is a Test Comment from User 2",
                },
                new Domain.Entities.Comment 
                {
                    Id = 3, 
                    UserId = 1,
                    PostId = 1,
                    Content = "This is a Test Comment from User 3",              
                }
            };

            var mockRepo = new Mock<ICommentRepository>(){ CallBase = true};

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(comments);

            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int id) => {
                var comment = comments.FirstOrDefault(x=> x.Id == id);
                return comment;
            });

            mockRepo.Setup(r => r.Add(It.IsAny<Domain.Entities.Comment>())).ReturnsAsync((Domain.Entities.Comment comment) => 
            {
                comments.Add(comment);
                return comment;
            });
            
            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>{
                var comment = comments.FirstOrDefault(x=> x.Id == id);
                return comment != null;
            });

            mockRepo.Setup(r => r.GetByPostId(It.IsAny<int>())).ReturnsAsync((int postId) => {
                var comment = comments.Where(x=> x.PostId == postId);
                return comment.ToList();
            });


            mockRepo.Setup(r => r.Update(It.IsAny<Domain.Entities.Comment>())).ReturnsAsync((Domain.Entities.Comment comment) => 
            {
                var commentToUpdate = comments.FirstOrDefault(x=> x.Id == comment.Id);
                commentToUpdate.Content = comment.Content;
                return commentToUpdate;
            });
            
            
            return mockRepo;

        }
    }
}
