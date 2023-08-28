using Application.Contracts.Persistence;
using Application.DTOs.Users;
using Application.features.Users.Handler.Queries;
using Application.Features.Users.Request;
using Application.Profiles;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Features.Users.Queries
{
    public class GetFollowersRequestHandlerUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockRepo;
        public GetFollowersRequestHandlerUnitTest()
        {
            _mockRepo = MockUserRepository.GetMockUserRepo();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async Task GetFollowersHandlerTest()
        {
            var handler = new GetUsersRequestHandler(_mockRepo.Object, _mapper);

            var getUsersRequest = new GetUsersRequest()
            {
                Id = 1,
                getFollowers = false
            };

            var result = await handler.Handle(getUsersRequest, CancellationToken.None);

            result.ShouldBeOfType<List<UserListDto>>();

            result.Count.ShouldBe(2);
        }

        [Fact]
        public async Task GetFolloweesHanldeTest()
        {
            var handler = new GetUsersRequestHandler(_mockRepo.Object, _mapper);

            var getUsersRequest = new GetUsersRequest()
            {
                Id = 1,
                getFollowers = true
            };

            var result = await handler.Handle(getUsersRequest, CancellationToken.None);

            result.ShouldBeOfType<List<UserListDto>>();

            result.Count.ShouldBe(1);

        }
    }
}
