using AutoMapper;
using Moq;
using Shouldly;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Handlers.Queries;
using SocialSync.Application.Features.Posts.Requests.Queries;
using SocialSync.Application.Profiles;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Posts.Handlers.Queries;

public class GetPostsByUserIdRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly GetPostsByUserIdRequestHandler _handler;

    public GetPostsByUserIdRequestHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetMockUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<PostsMappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new GetPostsByUserIdRequestHandler(_mockUow.Object, _mapper);
    }

    [Fact]
    public async Task ValidPostRetrieval()
    {
        int userId = 2;
        var response = await _handler.Handle(new GetPostsByUserIdRequest{UserId = userId}, CancellationToken.None);
        var expectedPostDtos = new List<PostDto> {
            new PostDto{
                Id = 1,
                UserId = 2,
                Content = "First Post",
                CreatedAt = DateTime.UtcNow.Date,
                LastModified = DateTime.UtcNow.Date
            },
            new PostDto{
                Id = 3,
                UserId = 2,
                Content = "Third Post",
                CreatedAt = DateTime.UtcNow.Date,
                LastModified = DateTime.UtcNow.Date
            }
        };


        response.Value.ShouldNotBeNull();
        response.Value.ShouldBeOfType(typeof(List<PostDto>));
        response.Value.Count().ShouldBe(2);
        response.Value.ShouldBeEquivalentTo(expectedPostDtos);

    }

    [Fact]
    public async Task EmptyPostRetrieval()
    {
        int userId = 100;
        var response = await _handler.Handle(new GetPostsByUserIdRequest{UserId = userId}, CancellationToken.None);
        response.Value.ShouldBeEmpty();
    }

}
