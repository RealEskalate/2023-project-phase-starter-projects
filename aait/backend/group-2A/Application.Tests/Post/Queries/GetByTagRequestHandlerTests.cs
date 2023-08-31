﻿using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Like.Handlers.Commands;
using Application.Features.Post.Handlers.Queries;
using Application.Features.Post.Request.Queries;
using Application.Profiles;
using Application.Responses;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Post.Queries
{
    public class GetByTagRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetByTagRequestHandler _handler;
        public GetByTagRequestHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new GetByTagRequestHandler(_mockRepo.Object, _mapper);
        }


        [Fact]
        public async Task GetByTag_ValidTag_ReturnsMatchingPosts()
        {
            var result = await _handler.Handle(new GetByTagRequest() { Tag = "tag2" }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeAssignableTo<IEnumerable<PostDto>>();
            result.Value.All(post => post.Tags.Contains("tag2")).ShouldBeTrue();
        }

        [Fact]
        public async Task GetByTag_InvalidTag_ReturnsEmptyList()
        {
            var result = await _handler.Handle(new GetByTagRequest() { Tag = "NonExistentTag" }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeEmpty();
        }

        [Fact]
        public async Task GetByTag_RepositoryError_Failure()
        {
            _mockRepo.Setup(repo => repo.postRepository.GetBytag(It.IsAny<string>())).ThrowsAsync(new Exception("Simulated error"));

            var result = await _handler.Handle(new GetByTagRequest() { Tag = "tag2" }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBeNull();
        }
    }
}
