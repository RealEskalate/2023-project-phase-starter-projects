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

public class CreatePostCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly CreatePostCommandHandler _handler;

    public CreatePostCommandHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetMockUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<PostsMappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new CreatePostCommandHandler(_mockUow.Object, _mapper);
    }

    [Fact]
    public async Task ValidPostCreationTest()
    {
        var postDto = new CreatePostDto
        {
            UserId = 2,
            Content = "This is the content of the fifth post"
        };
        var response = await _handler.Handle(new CreatePostCommand
        {
            CreatePostDto = postDto
        }
        , CancellationToken.None);

        var post = await _mockUow.Object.PostRepository.GetAsync(response.Value);

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeTrue();
        post.UserId.ShouldBe(2);
        post.Content.ShouldBe("This is the content of the fifth post");


    }

    [Fact]
    public async Task InvalidUserIdTest()
    {
        var postDto = new CreatePostDto
        {
            UserId = 100,
            Content = "This is the content of the fifth post",
        };
        var response = await _handler.Handle(new CreatePostCommand{
            CreatePostDto = postDto
        }, CancellationToken.None);
        var errorList = (List<string>)response.Error;

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeFalse();
        errorList.ShouldContain("Post author id doesnot match with any user id.");

    }

    [Fact]
    public async Task PostContentTooShortTest()
    {
        var postDto = new CreatePostDto
        {
            UserId = 2,
            Content = "",
        };
        var response = await _handler.Handle(new CreatePostCommand{
            CreatePostDto = postDto
        }, CancellationToken.None);
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
        var postDto = new CreatePostDto
        {
            UserId = 2,
            Content = longContent
        };
        var response = await _handler.Handle(new CreatePostCommand{
            CreatePostDto = postDto
        }, CancellationToken.None);
        var errorList = (List<string>)response.Error;

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeFalse();
        errorList.ShouldContain("Post content cannot have more than 500 characters.");

    }

    [Fact]
    public async Task NullPostContentTest()
    {

        var postDto = new CreatePostDto
        {
            UserId = 2,
            Content = null
        };
        var response = await _handler.Handle(new CreatePostCommand{
            CreatePostDto = postDto
        }, CancellationToken.None);
        var errorList = (List<string>)response.Error;

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeFalse();
        errorList.ShouldContain("Post content cannot be null.");

    }




}
