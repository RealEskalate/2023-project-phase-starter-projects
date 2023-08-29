// using Application.Contracts;
// using Application.DTO.PostDTO.DTO;
// using Application.Exceptions;
// using Application.Features.PostFeature.Handlers.Commands;
// using Application.Features.PostFeature.Requests.Commands;
// using Application.Profiles;
// using Application.Response;
// using Application.Tests.Mocks;
// using AutoMapper;
// using Domain.Entities;
// using Moq;
// using Shouldly;

// namespace Application.Tests.Features.PostFeatureTest.Commands
// {
//     public class UpdatePostHandlerTest
//     {
//             private readonly IMapper _mapper;
//         private readonly Mock<IPostRepository> _mockRepo;
//         public UpdatePostHandlerTest()
//         {
//              _mockRepo = MockPostRepository.GetPostRepository();

//             var mapperConfig = new MapperConfiguration(c => 
//             {
//                 c.AddProfile<MappingProfile>();
//             });

//             _mapper = mapperConfig.CreateMapper();   
//         }

//         public async Task UpdatePostValidTest()
//         {
//             var handler = new UpdatePostHandler(_mockRepo.Object,_mapper);

//             var updatedPost = new PostUpdateDTO(){
//                 Title = "new updated Data",
//                 Content = "new Updated Data content"
//             };
//             var result = await handler.Handle(new UpdatePostCommand(){Id = 1, userId = 1, PostUpdateData = updatedPost},CancellationToken.None);

//             result.ShouldBeOfType<BaseResponse<PostResponseDTO>>();
            
//         }


//         [Fact]
//         public async Task UpdatePostNonExistingPostTest()
//         {
//             // Arrange
//             _mockRepo.Setup(repo => repo.Exists(It.IsAny<int>())).ReturnsAsync(false);
//             var handler = new UpdatePostHandler(_mockRepo.Object, _mapper);

//             var updatedPost = new PostUpdateDTO()
//             {
//                 Title = "new updated Data",
//                 Content = "new Updated Data content"
//             };

//             // Act & Assert
//             await Should.ThrowAsync<NotFoundException>(async () =>
//                 await handler.Handle(new UpdatePostCommand() { Id = 1, userId = 1, PostUpdateData = updatedPost }, CancellationToken.None));
//             _mockRepo.Verify(repo => repo.Update(It.IsAny<Post>()), Times.Never);
//         }


//         [Fact]
//         public async Task UpdatePostInvalidDataTest()
//         {
//             // Arrange
//             var handler = new UpdatePostHandler(_mockRepo.Object, _mapper);

//             var updatedPost = new PostUpdateDTO(); // Invalid data, missing required properties

//             // Act & Assert
//             await Should.ThrowAsync<ValidationException>(async () =>
//                 await handler.Handle(new UpdatePostCommand() { Id = 1, userId = 1, PostUpdateData = updatedPost }, CancellationToken.None));
//             _mockRepo.Verify(repo => repo.Update(It.IsAny<Post>()), Times.Never);
//         }
//     }
// }