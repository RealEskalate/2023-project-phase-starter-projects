using Application.Contracts.Persistence;
using Domain.Entities;
using Moq;
using SocialSync.Application.Tests.Mocks.PostMock;

namespace SocialSync.Application.Tests.Mocks
{
    public static class MockPostRepository
    { 
        
        public static Mock<IPostRepository> GetPostRepository()
        {
            var posts = new List<Post>
            {
                new Post
                {
                    Id = 1,
                    UserId = 1,
                    Title = "first post",
                    Content = "first content",
                },
                new Post
                {
                    Id = 2,
                    UserId = 1,
                    Title = "second post",
                    Content = "second content",
                },
                new Post
                {
                    Id = 3,
                    UserId = 2,
                    Title = "third post",
                    Content = "third content",             
                }
            };

            var mockRepo = new Mock<IPostRepository>();
            // var tagMockRepo = MockTagRepository.GetTagRepository().Object;
            // var postTagMockRepo = MockPostTagRepository.GetPostTagRepository().Object;

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(posts);

            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int id) =>{
                var post = posts.FirstOrDefault(x=> x.Id == id);
                return post;
            });

            mockRepo.Setup(r => r.Add(It.IsAny<Post>())).ReturnsAsync((Post post) => 
            {
                posts.Add(post);
                return post;
            });
            
            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>{
                var post = posts.FirstOrDefault(x=> x.Id == id);
                return post != null;
            });
            return mockRepo;
            
            // mockRepo.Setup(r=>r.GetByTag(It.IsAny<string>())).Returns(async (string tagName)=>{
            //     var tagId = tagMockRepo.GetByTagName(tagName).Id;
            //     if(tagId == null){
            //         return;
            //     }
            //     var postIds =  await postTagMockRepo.GetPostsId(tagId);
                
            //     if(postIds == null){
            //         return;
            //     }
                
            // });
        }
    }
}
