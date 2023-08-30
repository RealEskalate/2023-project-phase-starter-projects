using Application.Contracts.Persistance;
using Application.DTO.FollowDTO;
using Application.DTO.Like;
using Application.Features.FollowFeatures.Handlers.Command;
using Application.Features.FollowFeatures.Request.Command;
using Application.Features.Like.Handlers.Commands;
using Application.Features.Like.Request.Commands;
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
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Like.Commands
{
    public class DeleteLikeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly LikedDto _likedDto;
        public DeleteLikeCommandHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

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
        }

        [Fact]
        public async Task DeleteLikeCommand_SuccessfullyDeletesLike()
        {
            var initialLikeCount = _mockRepo.Object.likeRepository.GetLikedPost(_likedDto.UserId).Result.Count;
            var handler = new DeleteLikeCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteLikeCommand() { like = _likedDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeTrue();

            var updatedLikeCount = _mockRepo.Object.likeRepository.GetLikedPost(_likedDto.UserId).Result.Count;
            updatedLikeCount.ShouldBe(initialLikeCount - 1);
        }

        [Fact]
        public async Task DeleteLikeCommand_LikeNotFound_ReturnsFailure()
        {
            _mockRepo.Setup(repo => repo.likeRepository.UnlikePost(It.IsAny<Domain.Entities.Like>())).ThrowsAsync(new Exception("Simulated error"));
            var handler = new DeleteLikeCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteLikeCommand() { like = _likedDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task DeleteLikeCommand_RepositoryError_ReturnsFailure()
        {
            _mockRepo.Setup(repo => repo.likeRepository.UnlikePost(It.IsAny<Domain.Entities.Like>())).ThrowsAsync(new Exception("Simulated error"));
            var handler = new DeleteLikeCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteLikeCommand() { like = _likedDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
        }
    }
}
