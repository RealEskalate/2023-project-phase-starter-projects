
using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Users;
using Application.features.Users.Handler.Queries;
using Application.Features.Users.Request;
using Application.Profiles;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.Users.Queries
{
    public class GetUserDetailHandlerUnitTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockRepo;
        public GetUserDetailHandlerUnitTest()
        {
            _mockRepo = MockUserRepository.GetMockUserRepo();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetUserDetailTest()
        {
            var handler = new GetUserDetailRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetUserDetailRequest() { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<UserDetail>();

            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task GetUserDetailTestShouldThrowNotFoundException()
        {
            var handler = new GetUserDetailRequestHandler(_mockRepo.Object, _mapper);

            await Should.ThrowAsync<NotFoundException>(handler.Handle(new GetUserDetailRequest() {  Id = 5} , CancellationToken.None));
        }

    }
}
