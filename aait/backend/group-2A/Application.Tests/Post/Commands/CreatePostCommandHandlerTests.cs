using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.DTO.Post;
using Application.Features.Comment.Handlers.Commands;
using Application.Features.Comment.Requests.Commands;
using Application.Features.Post.Handlers.Command;
using Application.Features.Post.Request.Commands;
using Application.Profiles;
using Application.Responses;
using Application.Tests.Mocks;
using AutoMapper;
using Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Post.Commands
{
    public class CreatePostCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreatePostDto _postDto;
        private readonly CreatePostCommandHandler _handler;

        public CreatePostCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });


            _postDto = new CreatePostDto
            {
                UserId = 2,
                Content = "Content 2",
                Tags = new List<string> { "tag1", "tag2" },
            };

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreatePostCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task CreatePostCommand_ValidData_CreatesPost()
        {
            var result = await _handler.Handle(new CreatePostCommand() { CreatePost = _postDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreatePostCommand_RepositoryError_Failure()
        {
            _mockRepo.Setup(repo => repo.postRepository.Add(It.IsAny<Domain.Entities.Post>())).ThrowsAsync(new Exception("Simulated error"));

            var result = await _handler.Handle(new CreatePostCommand() { CreatePost = _postDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(0);
        }
    }
}
