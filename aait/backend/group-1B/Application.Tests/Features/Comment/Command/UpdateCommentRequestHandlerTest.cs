using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Comments;
using Application.Features.Comments.Handlers.Commands;
using Application.Features.Comments.Requests.Commands;
using Application.Profiles;
using Application.Tests.Mocks.Comment;
using AutoMapper;
using Moq;
using Shouldly;
using SocialSync.Application.Tests.Mocks;

namespace Application.Tests.Features.Comment.Command;

public class UpdateCommentRequestHandlerTests
{
    private readonly Mock<ICommentRepository> _mockCommentRepo;
    private readonly Mock<IPostRepository> _mockPostRepo;
    private readonly IMapper _mapper;
    

    public UpdateCommentRequestHandlerTests()
    {
        _mockCommentRepo = MockCommentRepository.GetCommentRepository();
        _mockPostRepo = MockPostRepository.GetPostRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }
    [Fact]
    public async Task Handle_ValidRequest_ReturnsUpdatedComment()
    {
        var handler = new UpdateCommentRequestHandler(_mockCommentRepo.Object, _mockPostRepo.Object, _mapper);

        var updateDto = new UpdateCommentDto()
        {
            Id = 1,
            UserId = 1,
            PostId = 1,
            Content = "updated content"
        };
        var request = new UpdateCommentRequest() { Comment = updateDto };

        var result = await handler.Handle(request, CancellationToken.None);

        result.ShouldBeOfType<Domain.Entities.Comment>();
        
        result.Content.ShouldBe("updated content");

    }

    [Fact]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {

        var handler = new UpdateCommentRequestHandler(_mockCommentRepo.Object, _mockPostRepo.Object, _mapper);

        var updateDto = new UpdateCommentDto()
        {
            Id = 1,
            UserId = 1,
            PostId = 1,
            Content = ""
        };

        var request = new UpdateCommentRequest() { Comment = updateDto };

        await Should.ThrowAsync<ValidationException>(async () => await handler.Handle(request, CancellationToken.None));
        
      
    }
}