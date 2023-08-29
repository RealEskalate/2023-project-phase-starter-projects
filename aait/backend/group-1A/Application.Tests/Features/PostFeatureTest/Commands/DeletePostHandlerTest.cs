// using Application.Contracts;
// using Application.Exceptions;
// using Application.Features.PostFeature.Handlers.Commands;
// using Application.Features.PostFeature.Requests.Commands;
// using Application.Profiles;
// using Application.Tests.Mocks;
// using AutoMapper;
// using Moq;
// using Shouldly;

// namespace Application.Tests.Features.PostFeatureTest.Commands
// {
//     public class DeletePostHandlerTest
//     {
//          private readonly IMapper _mapper;
//         private readonly Mock<IPostRepository> _mockRepo;

//         public DeletePostHandlerTest()
//         {
//             _mockRepo = MockPostRepository.GetPostRepository();

//             var mapperConfig = new MapperConfiguration(c => 
//             {
//                 c.AddProfile<MappingProfile>();
//             });

//             _mapper = mapperConfig.CreateMapper();
//         }

//         [Fact]
//         public async Task DeletePostValidTest()
//         {
//             var handler = new DeletePostHandler(_mockRepo.Object);

//             var result = await handler.Handle(new DeletePostCommand(){userId = 1, Id = 1}, CancellationToken.None);

//             //result.ShouldBeOfType<BaseResponse<PostResponseDTO>>();
//             Assert.NotNull(result);

//         }


//         [Fact]
//         public async Task DeleteUnExistingPost_ValidationFailure()
//         {
//             var handler = new DeletePostHandler(_mockRepo.Object);


//             await Should.ThrowAsync<NotFoundException>(async () =>
//                 await handler.Handle(new DeletePostCommand() { userId = 1, Id = 100 }, CancellationToken.None));


//         }


//         [Fact]
//         public async Task DeleteUnAuthorizedgPost_ValidationFailure()
//         {
//             var handler = new DeletePostHandler(_mockRepo.Object);

//             await Should.ThrowAsync<NotFoundException>(async () =>
//                 await handler.Handle(new DeletePostCommand() { userId = 1000, Id = 1 }, CancellationToken.None));

//         }
//     }
// }