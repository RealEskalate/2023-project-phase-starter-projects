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

public class GetAllPostsRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly GetAllPostsRequestHandler  _handler;

    public GetAllPostsRequestHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetMockUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<PostsMappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new GetAllPostsRequestHandler(_mockUow.Object, _mapper);
    }

    [Fact]
    public async Task ValidPostRetrieval()
    {

        var response = await _handler.Handle(new GetAllPostsRequest(), CancellationToken.None);
        var expectedMappedList = _mapper.Map<List<PostDto>>(await _mockUow.Object.PostRepository.GetAsync());


        response.ShouldNotBeNull();
        response.Value.ShouldBeOfType(typeof(List<PostDto>));
        response.Value.Count().ShouldBe(4);
        response.Value.ShouldBeEquivalentTo(expectedMappedList);

    }

}
