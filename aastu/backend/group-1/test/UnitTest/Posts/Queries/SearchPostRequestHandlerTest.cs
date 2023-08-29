using AutoMapper;
using Moq;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Posts.Handler.Queries;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using FluentAssertions;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Application.UnitTests.Features.Posts.Handler.Queries
{
    public class SearchPostRequestHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsPostDtos()
        {
            // Arrange
            var query = "example";
            var posts = new List<Post> { new Post { Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"), Title = "Example Post" } };
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(repo => repo.SearchPosts(query))
                .ReturnsAsync(posts);
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<List<PostDto>>(posts))
                .Returns(new List<PostDto> { new PostDto { Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"), Title = "Example Post" } });
            var searchPostRequest = new SearchPostRequest { query = query };
            var searchPostRequestHandler = new SearchPostRequestHandler(postRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await searchPostRequestHandler.Handle(searchPostRequest, CancellationToken.None);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<List<PostDto>>();
            result.Count.ShouldBe(1);
            result[0].Id.ShouldBe(Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"));
            result[0].Title.ShouldBe("Example Post");
        }

        [Fact]
        public async Task Handle_NoPostsFound_ThrowsNotFoundException()
        {
            // Arrange
            var query = "example";
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(repo => repo.SearchPosts(query))
                .ReturnsAsync((List<Post>)null);
            var mapperMock = new Mock<IMapper>();
            var searchPostRequest = new SearchPostRequest { query = query };
            var searchPostRequestHandler = new SearchPostRequestHandler(postRepositoryMock.Object, mapperMock.Object);

            // Act & Assert
            await Should.ThrowAsync<NotFoundException>(async () =>
            {
                await searchPostRequestHandler.Handle(searchPostRequest, CancellationToken.None);
            });
        }
    }
}