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

public class GetPostByIdRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly GetPostByIdRequestHandler  _handler;

    public GetPostByIdRequestHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetMockUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<PostsMappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new GetPostByIdRequestHandler(_mockUow.Object, _mapper);
    }

    [Fact]
    public async Task ValidPostRetrieval()
    {

        int id = 1;
        var response = await _handler.Handle(new GetPostByIdRequest{Id = id}, CancellationToken.None);


        response.Value.ShouldNotBeNull();
        response.Value.ShouldBeOfType(typeof(PostDto));
        response.Value.ShouldBeEquivalentTo(new PostDto{
            Id = 1,
            UserId = 2,
            Content = "First Post",
            CreatedAt = DateTime.UtcNow.Date,
            LastModified = DateTime.UtcNow.Date
        });

    }

    [Fact]
    public async Task InvalidPostRetrieval()
    {

        int id = 300;
        var response = await _handler.Handle(new GetPostByIdRequest{Id = id}, CancellationToken.None);

        response.Value.ShouldBeNull();

    }

}
