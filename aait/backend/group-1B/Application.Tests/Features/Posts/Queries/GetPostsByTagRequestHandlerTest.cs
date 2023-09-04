// using Application.Contracts.Persistence;
// using Application.DTOs.Posts;
// using Application.Features.Posts.Handlers.Queries;
// using Application.Features.Posts.Requests.Queries;
// using Application.Profiles;
// using AutoMapper;
// using AutoMapper.Configuration.Annotations;
// using Domain.Entities;
// using MediatR;
// using Moq;
// using Shouldly;
// using SocialSync.Application.Tests.Mocks;
// using SocialSync.Application.Tests.Mocks.PostMock;

// namespace SocialSync.Application.Tests.Posts.Queries
// {
//     public class GetPostsByTagRequestHandlerTest
//     {
//         private readonly IMapper _mapper;
//         private readonly Mock<IPostRepository> _postMockRepo;
//         private readonly Mock<ITagRepository> _tagMockRepo;
//         private readonly Mock<IPostTagRepository> _postTagMockRepo;
//         public GetPostsByTagRequestHandlerTest()
//         {
//             _postTagMockRepo = MockPostTagRepository.GetPostTagRepository();
//             _postMockRepo  = MockPostRepository.GetPostRepository();
//             _tagMockRepo = MockTagRepository.GetTagRepository();

//             var mapperConfig = new MapperConfiguration(c => 
//             {
//                 c.AddProfile<MappingProfile>();
//             });

//             _mapper = mapperConfig.CreateMapper();
//         }

        
//         [Fact]
//         public async Task GetPostListByTagTest()
//         {
//             var handler = new GetPostsByTagRequestHandler(_postMockRepo.Object, _mapper);

//             var result = await handler.Handle(new GetPostsByTagRequest(){Tag = "firstTag"}, CancellationToken.None);

//             result.ShouldBeOfType<List<Post>>();
//         }


        
        
        
// }
     
    

// }