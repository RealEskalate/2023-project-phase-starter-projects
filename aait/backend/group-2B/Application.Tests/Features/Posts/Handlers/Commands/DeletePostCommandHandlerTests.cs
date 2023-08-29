using AutoMapper;
using Moq;
using Shouldly;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Handlers.Commands;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Profiles;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Posts.Handlers.Commands;

public class DeleteCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly DeletePostCommandHandler _handler;

    public DeleteCommandHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetMockUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<PostsMappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new DeletePostCommandHandler(_mockUow.Object, _mapper);
    }

    [Fact]
    public async Task ValidPostDeletionTest()
    {
        var postDto = new DeletePostDto{
            Id = 3,
            UserId = 2
        };
        var response = await _handler.Handle(new DeletePostCommand{DeletePostDto = postDto}, CancellationToken.None);


        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public async Task InvalidPostId()
    {
        var postDto = new DeletePostDto{
            Id = 100,
            UserId = 3
        };
        var response = await _handler.Handle(new DeletePostCommand{DeletePostDto = postDto}, CancellationToken.None);
        var errorList = (List<string>)response.Error;

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeFalse();
        errorList.ShouldContain("Given id did not match any post id.");

    }

    [Fact]
    public async Task UnauthorizedUserId()
    {
        var postDto = new DeletePostDto{
            Id = 2,
            UserId = 4
        };
        var response = await _handler.Handle(new DeletePostCommand{DeletePostDto = postDto}, CancellationToken.None);
        var errorList = (List<string>)response.Error;

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeFalse();
        errorList.ShouldContain("Post author id does not match with the id of author of the post being deleted.");

    }

}
