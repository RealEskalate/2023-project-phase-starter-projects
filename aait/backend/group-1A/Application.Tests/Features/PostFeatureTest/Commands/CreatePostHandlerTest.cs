
using Application.Contracts;
using Application.DTO.PostDTO.DTO;
using Application.Exceptions;
using Application.Features.PostFeature.Handlers.Commands;
using Application.Features.PostFeature.Requests.Commands;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using AutoMapper;
using Domain.Entities;
using Moq;
using Shouldly;

namespace Application.Tests.Features.PostFeatureTest.Commands
{
    public class CreatePostHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepo;
        public CreatePostHandlerTest()
        {
            _mockRepo = MockPostRepository.GetPostRepository();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task ValidCreatePostTest()
        {
            // arrange 
            var handler = new CreatePostHandler(_mapper,_mockRepo.Object);
            var newPost = new PostCreateDTO(){
                Title = "New post",
                Content = "New post Content"
            };

            // act
            var result = await handler.Handle(new CreatePostCommand(){userId = 1, NewPostData = newPost}, CancellationToken.None);
            // asset
            result.ShouldBeOfType<BaseResponse<PostResponseDTO>>();
            result.Value.ShouldNotBeNull();
        }



        [Fact]
        public async Task InvalidCreatePostTest_ValidationFailure()
        {
            // Arrange
            var handler = new CreatePostHandler(_mapper, _mockRepo.Object);
            var newPost = new PostCreateDTO();

            // Act & Assert
            await Should.ThrowAsync<ValidationException>(async () =>
            await handler.Handle(new CreatePostCommand() { userId = 1, NewPostData = newPost }, CancellationToken.None));
            _mockRepo.Verify(repo => repo.Add(It.IsAny<Post>()), Times.Never);
        }



        [Fact]
        public async Task InvalidCreatePostTest_ExceptionInRepository()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.Add(It.IsAny<Post>())).ThrowsAsync(new Exception("Repository error"));
            var handler = new CreatePostHandler(_mapper, _mockRepo.Object);
            var newPost = new PostCreateDTO()
            {
                Title = "New post",
                Content = "New post Content"
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() =>
                handler.Handle(new CreatePostCommand() { userId = 1, NewPostData = newPost }, CancellationToken.None));
            _mockRepo.Verify(repo => repo.Add(It.IsAny<Post>()), Times.Once);
        }
        
    }
}