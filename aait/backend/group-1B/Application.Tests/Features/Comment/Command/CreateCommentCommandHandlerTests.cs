
using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Comments;
using Application.Features.Comments.Handlers.Commands;
using Application.Features.Comments.Requests.Commands;
using Application.Profiles;
using AutoMapper;
using Moq;
using Shouldly;
using SocialSync.Application.Tests.Mocks.PostMock.PostMock;



namespace Application.Tests.Features.Comment.Command;

public class CreateCommentRequestHandlerTests
{

    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly IMapper _mapper;

    public CreateCommentRequestHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }
    [Fact]
    public async Task Handle_ValidRequest_ReturnsCommentContentDto()
    {
        
        
        var handler = new CreateCommentRequestHandler(_mockUow.Object, _mapper);

        var request = new CreateCommentRequest
        {
            Comment = new CreateCommentDto
            {
                UserId = 1,
                PostId = 1,
                Content = "test"
            }
        };
        

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        result.ShouldBeOfType<CommentContentDto>();
        result.Content.ShouldBe("test");

        
    }

    [Fact]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        
        var handler = new CreateCommentRequestHandler(_mockUow.Object, _mapper);

        var request = new CreateCommentRequest
        {
            Comment = new CreateCommentDto
            {
                UserId = 1,
                PostId = 1,
                Content = ""
            }
        };

        // Act
        var result = await Should.ThrowAsync<ValidationException>(async () => await handler.Handle(request, CancellationToken.None));
      
    }
}