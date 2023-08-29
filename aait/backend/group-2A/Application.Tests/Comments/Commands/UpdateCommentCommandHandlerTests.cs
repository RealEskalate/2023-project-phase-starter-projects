using Application.Contracts.Persistance;
using Application.Features.Comment.Handlers.Commands;
using Application.Features.Comment.Requests.Commands;
using Application.Profiles;
using Application.Responses;
using Application.Tests.Mocks;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Moq;
using Shouldly;


namespace Application.Tests.Comments.Commands
{
    public class UpdateCommentCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;

        public UpdateCommentCommandHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

   

    [Fact]
    public async Task UpdateCommentCommand_ValidData_Success()
    {
        var commentToUpdate = _mockRepo.Object.commentRepository.Get(1).Result;
        var updatedContent = "Updated Comment Content";
        var updateCommand = new UpdateCommentCommand
        {
            Id = commentToUpdate.Id,
            Content = updatedContent
        };

        var handler = new UpdateCommentCommandHandler(_mockRepo.Object, _mapper);

        // Act
        var result = await handler.Handle(updateCommand, CancellationToken.None);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<BaseCommandResponse<Unit>>();
        result.Success.ShouldBeTrue();
        result.Value.ShouldBe(Unit.Value);

        // Verify that the comment was updated
        var updatedComment = await _mockRepo.Object.commentRepository.Get(commentToUpdate.Id);
        updatedComment.ShouldNotBeNull();
        updatedComment.Content.ShouldBe(updatedContent);
    }

    [Fact]
    public async Task UpdateCommentCommand_CommentNotFound_Failure()
    {
        // Arrange
        var updateCommand = new UpdateCommentCommand
        {
            Id = 999, // Non-existing comment ID
            Content = "Updated Comment Content"
        };

        var handler = new UpdateCommentCommandHandler(_mockRepo.Object, _mapper);

        // Act
        var result = await handler.Handle(updateCommand, CancellationToken.None);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<BaseCommandResponse<Unit>>();
        result.Success.ShouldBeFalse();
        result.Message.ShouldNotBeNull();
        result.Data.ShouldBe(Unit.Value);
    }

    [Fact]
    public async Task UpdateCommentCommand_RepositoryError_Failure()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.commentRepository.Update(It.IsAny<Comment>())).ThrowsAsync(new Exception("Simulated error"));

        var commentToUpdate = _mockRepo.Object.commentRepository.Get(1).Result;
        var updateCommand = new UpdateCommentCommand
        {
            Id = commentToUpdate.Id,
            Content = "Updated Comment Content"
        };

        var handler = new UpdateCommentCommandHandler(_mockRepo.Object, _mapper);

        // Act
        var result = await handler.Handle(updateCommand, CancellationToken.None);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<BaseCommandResponse<Unit>>();
        result.Success.ShouldBeFalse();
        result.Message.ShouldNotBeNull();
        result.Data.ShouldBe(Unit.Value);
    }
}
}
