using Application.Contracts.Persistence;
using Application.DTOs.Posts;
using Application.Features.PostLikes.Requests.Queries;
using Domain.Entities;
using Moq;

namespace SocialSync.Application.Tests.Mocks.PostMock
{
    public static class MockPostTagRepository
    {
        public static Mock<IPostTagRepository> GetPostTagRepository()
        {
            var postTags = new List<PostTag>
            {
                new PostTag
                {
                    TagId = 1,
                    PostId = 1
                },
                new PostTag
                {
                    TagId = 1,
                    PostId = 2
                },
                new PostTag
                {
                    TagId = 2,
                    PostId = 3                
                },
                new PostTag
                {
                    TagId = 3,
                    PostId = 1                
                }
            };

            // var mockTagRepository = MockTagRepository.GetTagRepository();
            // var tagMockRepo = MockTagRepository.GetTagRepository().Object;
            var postMockRepo = MockPostRepository.GetPostRepository().Object;
            

            var mockRepo = new Mock<IPostTagRepository>();
            

            
            // mockRepo.Setup(r=>r.AddTagToPost(It.IsAny<int>(), It.IsAny<string>())).Returns((int postId, string tagName)=>{
            //     var postExists = postMockRepo.Exists(postId);
            //     var tagExists = tagMockRepo.ExistsByTagName(tagName);
                
            //     if(postExists == Task.FromResult(false)){
            //         // the post doesnt exist
            //         return;
            //     }
            //     //creating the tag if its not in the tag table
            //     if(tagMockRepo.ExistsByTagName(tagName) == Task.FromResult(false)){
            //         var tagNameDto  = new TagNameDto(){
            //             TagName = tagName
            //         };
            //         tagMockRepo.AddTag(tagNameDto);
            //     }

            //     var tag = tagMockRepo.GetByTagName(tagName);
            //     var postTag = new PostTag(){
            //         TagId = tag.Id,
            //         PostId = postId            
            //     };
            //     postTags.Add(postTag);                
            // });

            // mockRepo.Setup(r=>r.GetTagId(It.IsAny<string>())).Returns((string tagName)=>{
            //     return tagMockRepo.GetByTagName(tagName).Id;
            // });
            
            // mockRepo.Setup(r=>r.GetPostsId(It.IsAny<int>())).Returns((int tagId)=>{
            //     var result = postTags.Where(x=>x.TagId == tagId).Select(x=>x.PostId).ToList();
            //     return result;
            // });

            

            
            return mockRepo;

        }
    }
}
