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

public class GetPostsByTagsRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly GetPostsByTagsRequestHandler _handler;

    public GetPostsByTagsRequestHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetMockUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<PostsMappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new GetPostsByTagsRequestHandler(_mockUow.Object, _mapper);
    }

    [Fact]
    public async Task MultiTaggedPostRetrieval()
    {
        var tags = new List<string>{"#tag1", "#tag2"};
        var response = await _handler.Handle(new GetPostsByTagsRequest{Tags = tags}, CancellationToken.None);
        var expectedPostDtos = new List<PostDto> {
            new PostDto{
                Id = 2,
                UserId = 3,
                Content = "Second Post #tag1",
                CreatedAt = DateTime.UtcNow.Date,
                LastModified = DateTime.UtcNow.Date

            },
            new PostDto{
                Id = 4,
                UserId = 1,
                Content = "Fourth Post #tag2",
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
    public async Task MonoTaggedPostRetrieval()
    {
        var tags = new List<string>{"#tag1"};
        var response = await _handler.Handle(new GetPostsByTagsRequest{Tags = tags}, CancellationToken.None);
        var expectedPostDtos = new List<PostDto> {
            new PostDto{
                Id = 2,
                UserId = 3,
                Content = "Second Post #tag1",
                CreatedAt = DateTime.UtcNow.Date,
                LastModified = DateTime.UtcNow.Date

            }
        };


        response.Value.ShouldNotBeNull();
        response.Value.ShouldBeOfType(typeof(List<PostDto>));
        response.Value.Count().ShouldBe(1);
        response.Value.ShouldBeEquivalentTo(expectedPostDtos);

    }
    [Fact]
    public async Task EmptyPostRetrieval()
    {
        var tags = new List<string>{"#tag3"};
        var response = await _handler.Handle(new GetPostsByTagsRequest{Tags = tags}, CancellationToken.None);
        response.Value.ShouldNotBeNull();
        response.Value.ShouldBeEmpty();

    }





}
