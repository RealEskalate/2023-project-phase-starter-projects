using AutoMapper;
using FluentValidation.TestHelper;
using MediatR;
using Moq;
using Shouldly;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.DTOs.Posts.Validators;
using SocialMediaApp.Application.Features.Posts.Handler.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SocialMediaApp.Application.UnitTests.Features.Posts.Handler.Commands
{
    public class UpdatePostsCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_PostUpdated()
        {
            // Arrange
            var postId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8");
            var updatePostDto = new UpdatePostDto { Id = postId, Title = "New Title", Content="people" };
            var post = new Post { Id = postId, Title = "Old Title", Content= "sheesh" };
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(p => p.Add(post)).ReturnsAsync(post);
            postRepositoryMock.Setup(repo => repo.GetById(postId))
                .ReturnsAsync(post);
            //postRepositoryMock.Setup(repo => repo.Update()).Returns(Task.CompletedTask);

            var mapperMock = new Mock<IMapper>();
            var updatePostDtoValidator = new UpdatePostDtoValidator(postRepositoryMock.Object);
            var validationResult = await updatePostDtoValidator.ValidateAsync(updatePostDto);
            var updatePostsCommand = new UpdatePostsCommand { post = updatePostDto };
            var updatePostsCommandHandler = new UpdatePostsCommandHandler(postRepositoryMock.Object, mapperMock.Object);
            
            // Act
            var result  = await updatePostsCommandHandler.Handle(updatePostsCommand, CancellationToken.None);
            var fetchPost = await postRepositoryMock.Object.GetById(postId);
            // Assert
            Assert.True(validationResult.IsValid);
            Assert.IsType<Unit>(result);
            mapperMock.Verify(mapper => mapper.Map(updatePostDto, post), Times.Once);
            postRepositoryMock.Verify(repo => repo.Update(post), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ValidationFails_PostNotUpdated()
        {
            // Arrange
            var postId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8");
            var updatePostDto = new UpdatePostDto { Id = postId, Title = null }; // Invalid data
            var postRepositoryMock = new Mock<IPostRepository>();
            var mapperMock = new Mock<IMapper>();
            var updatePostDtoValidator = new UpdatePostDtoValidator(postRepositoryMock.Object);
            var validationResult = await updatePostDtoValidator.TestValidateAsync(updatePostDto);
            var updatePostsCommand = new UpdatePostsCommand { post = updatePostDto };
            var updatePostsCommandHandler = new UpdatePostsCommandHandler(postRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await updatePostsCommandHandler.Handle(updatePostsCommand, CancellationToken.None);

            // Assert
            result.ShouldBe(Unit.Value);
            validationResult.ShouldHaveValidationErrorFor(dto => dto.Title);
            postRepositoryMock.Verify(repo => repo.Update(It.IsAny<Post>()), Times.Never);
        }
    }
}