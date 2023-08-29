using Application.Contracts.Persistance;
using Application.DTO.FollowDTO;
using Application.DTO.Like;
using Application.Features.FollowFeatures.Handlers.Command;
using Application.Features.FollowFeatures.Request.Command;
using Application.Features.Like.Handlers.Query;
using Application.Features.Like.Request.Queries;
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

namespace Application.Tests.Like.Queries
{
    public class GetIsLikedQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly LikedDto _likedDto;
        public GetIsLikedQueryHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _likedDto = new LikedDto
            {
                PostId = 1,
                UserId = 2,
            };

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetIsLiked()
        {
            var handler = new GetIsLikedQueryHander(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetIsLikedQuery() { LikedDto = _likedDto}, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse<bool>>();

        }
    }
}
