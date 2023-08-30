using Application.Contracts.Persistance;
using Application.DTO.FollowDTO;
using Application.DTO.Like;
using Application.Features.Comment.Handlers.Queries;
using Application.Features.FollowFeatures.Handlers.Command;
using Application.Features.FollowFeatures.Request.Command;
using Application.Features.Like.Handlers.Commands;
using Application.Profiles;
using Application.Responses;
using Application.Tests.Mocks;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Like.Commands
{
    public class CreateLikeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly LikedDto _likedDto;
        private readonly CreateLikeCommandHandler _handler;
        public CreateLikeCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _likedDto = new LikedDto
            {
                UserId = 1,
                PostId = 1,
            };

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateLikeCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task CreateLikeCommand_SuccessfullyCreatesLike()
        {
            var result = await _handler.Handle(new CreateLikeCommand() { like = _likedDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Errors.ShouldBeNull();
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task CreateLikeCommand_RepositoryError_ReturnsFailure()
        {
            _mockRepo.Setup(repo => repo.likeRepository.LikePost(It.IsAny<Domain.Entities.Like>())).ThrowsAsync(new Exception("Simulated error"));

            var result = await _handler.Handle(new CreateLikeCommand() { like = _likedDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
        }
    }
}
