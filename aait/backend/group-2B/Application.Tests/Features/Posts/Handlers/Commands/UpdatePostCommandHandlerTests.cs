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

public class UpdatePostCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly UpdatePostCommandHandler _handler;

    public UpdatePostCommandHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetMockUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<PostsMappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new UpdatePostCommandHandler(_mockUow.Object, _mapper);
    }

    [Fact]
    public async Task ValidPostUpdateTest()
    {
        var postDto = new UpdatePostDto
        {
            Id = 4,
            UserId = 1,
            Content = "This is the new content of the fourth post"
        };
        var response = await _handler.Handle(new UpdatePostCommand{UpdatePostDto = postDto}
        , CancellationToken.None);

        var post = await _mockUow.Object.PostRepository.GetAsync(4);

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeTrue();
        post.Content.ShouldBe("This is the new content of the fourth post");


    }

    [Fact]
    public async Task InvalidUserIdTest()
    {
        var postDto = new UpdatePostDto
        {
            Id = 4,
            UserId = 100,
            Content = "This is the new content of the fourth post",
        };
        var response = await _handler.Handle(new UpdatePostCommand{UpdatePostDto = postDto}, CancellationToken.None);
        var errorList = (List<string>)response.Error;

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeFalse();
        errorList.ShouldContain("Post author id does not match with the id of author of the post being updated.");

    }

    [Fact]
    public async Task UnauthorizedUserTest()
    {
        var postDto = new UpdatePostDto
        {
            Id = 4,
            UserId = 2,
            Content = "This is the new content of the fourth post",
        };
        var response = await _handler.Handle(new UpdatePostCommand{UpdatePostDto = postDto}, CancellationToken.None);
        var errorList = (List<string>)response.Error;

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeFalse();
        errorList.ShouldContain("Post author id does not match with the id of author of the post being updated.");

    }

    [Fact]
    public async Task PostContentTooShortTest()
    {
        var postDto = new UpdatePostDto
        {
            Id = 4,
            UserId = 1,
            Content = "",
        };
        var response = await _handler.Handle(new UpdatePostCommand{UpdatePostDto = postDto}, CancellationToken.None);
        var errorList = (List<string>)response.Error;

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeFalse();
        errorList.ShouldContain("Post content cannot be empty.");

    }
    [Fact]
    public async Task PostContentTooLongTest()
    {

        string longContent = "1";
        for (int i = 0; i < 10; i++)
        {
            longContent += longContent;
        }
        var postDto = new UpdatePostDto
        {
            Id = 4,
            UserId = 1,
            Content = longContent
        };
        var response = await _handler.Handle(new UpdatePostCommand{UpdatePostDto = postDto}, CancellationToken.None);
        var errorList = (List<string>)response.Error;


        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeFalse();
        errorList.ShouldContain("Post content cannot have more than 500 characters.");

    }

    [Fact]
    public async Task NullPostContentTest()
    {

        var postDto = new UpdatePostDto
        {
            Id = 4,
            UserId = 1,
            Content = null
        };
        var response = await _handler.Handle(new UpdatePostCommand{UpdatePostDto = postDto}, CancellationToken.None);
        var errorList = (List<string>)response.Error;

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeFalse();
        errorList.ShouldContain("Post content cannot be null.");

    }




}
