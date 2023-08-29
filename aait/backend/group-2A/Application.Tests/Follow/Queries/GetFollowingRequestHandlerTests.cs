using Application.Contracts.Persistance;
using Application.DTO.FollowDTO;
using Application.DTO.UserDTO;
using Application.Features.FollowFeatures.Handlers.Command;
using Application.Features.FollowFeatures.Handlers.Queries;
using Application.Features.FollowFeatures.Request.Command;
using Application.Features.FollowFeatures.Request.Queries;
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

namespace Application.Tests.Follow.Queries
{
    public class GetFollowingRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        public GetFollowingRequestHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetFollowing()
        {
            var handler = new GetFollowingRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetFollowingRequest() { Id = 1}, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();

        }
    }
}
