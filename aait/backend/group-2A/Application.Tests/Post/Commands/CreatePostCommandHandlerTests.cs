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

        public CreatePostCommandHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });


            _postDto = new CreatePostDto
            {
                UserId = 5,
                Content = "Content 2",
                Tags = new List<string> { "tag1", "tag2" },
            };

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task CreatePostCommand_ValidData_CreatesPost()
        {
            var initialPostList = await _mockRepo.Object.postRepository.GetAll();
            var initialPostCount = initialPostList.Count;
            var handler = new CreatePostCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new CreatePostCommand() { CreatePost = _postDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeGreaterThan(0);

            var updatedPostList = await _mockRepo.Object.postRepository.GetAll();
            var updatedPostCount = updatedPostList.Count;
            updatedPostCount.ShouldBe(initialPostCount + 1);
        }

        [Fact]
        public async Task CreatePostCommand_RepositoryError_Failure()
        {
            _mockRepo.Setup(repo => repo.postRepository.Add(It.IsAny<Domain.Entities.Post>())).ThrowsAsync(new Exception("Simulated error"));
            var handler = new CreatePostCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new CreatePostCommand() { CreatePost = _postDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(0);
        }
    }
}
