// using Application.Contracts.Persistence;
// using Application.DTOs.Posts;
// using Application.Features.PostLikes.Requests.Queries;
// using Domain.Entities;
// using Moq;

// namespace SocialSync.Application.Tests.Mocks.PostMock
// {
//     public static class MockTagRepository
//     {
//         public static Mock<ITagRepository> GetTagRepository()
//         {
//             var tags = new List<Tag>
//             {
//                 new Tag
//                 {
//                     Id = 1,
//                     TagName = "firsttag"
//                 },
//                 new Tag
//                 {
//                     Id = 2,
//                     TagName = "secondtag"
//                 },
//                 new Tag
//                 {
//                     Id = 3,
//                     TagName = "thirdtag"                
//                 }
//             };

//             var mockRepo = new Mock<ITagRepository>();
//             mockRepo.Setup(r => r.ExistsByTagName(It.IsAny<string>())).Returns((string tagName) => 
//             {
//                 var tag = tags.FirstOrDefault(x=>x.TagName == tagName.ToLower());
//                 return Task.FromResult(tag != null);
//             });
//             mockRepo.Setup(r => r.GetByTagName(It.IsAny<string>())).Returns((string tagName) => 
//             {
//                 var tag = tags.FirstOrDefault(x=> x.TagName == tagName.ToLower());
//                 return tag;
//             });
//             mockRepo.Setup(r => r.AddTag(It.IsAny<TagNameDto>())).Returns((TagNameDto tagNameDto)=>{
//                 var tagName = tagNameDto.TagName;
//                 var tagExists = mockRepo.Object.ExistsByTagName(tagName);
//                 if(tagExists == Task.FromResult(false))            
//                 {
//                     tags.Add( new Tag{
//                         Id = 4, 
//                         TagName = tagNameDto.TagName.ToLower()
//                     });
//                 }
//             });
            
//             return mockRepo;

//         }
//     }
// }
