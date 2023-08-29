using AutoMapper;
using Moq;
using Shouldly;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Posts.Handler.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SocialMediaApp.Application.UnitTests.Features.Posts.Handler.Commands
{
    public class DeletePostCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_PostDeleted()
        {
            // Arrange
            var userId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8");
            var postId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8");
            var post = new Post { Id = postId, UserId = userId };
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(repo => repo.GetById(postId))
                .ReturnsAsync(post);
            var mapperMock = new Mock<IMapper>();
            var deletePostCommand = new DeletePostCommand { Id = postId, UserId = userId };
            var deletePostCommandHandler = new DeletePostCommandHandler(postRepositoryMock.Object, mapperMock.Object);

            // Act
            await deletePostCommandHandler.Handle(deletePostCommand, CancellationToken.None);

            // Assert
            postRepositoryMock.Verify(repo => repo.Delete(post), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidPostId_ThrowsNotFoundException()
        {
            // Arrange
            var userId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8");
            var postId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8");
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(repo => repo.GetById(postId))
                .ReturnsAsync((Post)null);
            var mapperMock = new Mock<IMapper>();
            var deletePostCommand = new DeletePostCommand { Id = postId, UserId = userId };
            var deletePostCommandHandler = new DeletePostCommandHandler(postRepositoryMock.Object, mapperMock.Object);

            // Act & Assert
            await Should.ThrowAsync<NotFoundException>(() => deletePostCommandHandler.Handle(deletePostCommand, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange
            var userId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8");
            var postId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8");
            var post = new Post { Id = postId, UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b86e2efc8") }; // Different user ID
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(repo => repo.GetById(postId))
                .ReturnsAsync(post);
            var mapperMock = new Mock<IMapper>();
            var deletePostCommand = new DeletePostCommand { Id = postId, UserId = userId };
            var deletePostCommandHandler = new DeletePostCommandHandler(postRepositoryMock.Object, mapperMock.Object);

            // Act & Assert
            await Should.ThrowAsync<NotFoundException>(() => deletePostCommandHandler.Handle(deletePostCommand, CancellationToken.None));
        }
    }
}