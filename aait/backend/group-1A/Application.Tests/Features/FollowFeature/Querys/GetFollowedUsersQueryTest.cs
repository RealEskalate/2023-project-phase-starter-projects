using Application.Contracts;
using Application.DTO.FollowDTo;
using Application.DTO.UserDTO.DTO;
using Application.Features.FollowFeature.Handlers.Queries;
using Application.Features.FollowFeature.Requests.Queries;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.FollowFeature.Commands
{
    public class GetFollowedUsersQueryTest
    {            
            private readonly Mock<IUnitOfWork> _mockUnitOfWork;    
            private readonly IMapper _mapper;
            private readonly FollowDTO _followDTO;
            private  GetFollowedUsersQueryHandler _handler;
            public GetFollowedUsersQueryTest()
            {
                _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

                var mapperConfig = new MapperConfiguration(c => 
                {
                    c.AddProfile<MappingProfile>();
                });

                _mapper = mapperConfig.CreateMapper();

            }

        [Fact]
        public async Task GetFolloweesOfValidUser()
        {
            _handler = new GetFollowedUsersQueryHandler(_mockUnitOfWork.Object,_mapper);
                         
            var result = await _handler.Handle(new GetFollowedUsersQuery() { Id = 2 }, CancellationToken.None);
            result.Value.Count().ShouldBe(1);
            result.ShouldBeOfType<BaseResponse<List<UserResponseDTO>>>();
        }
        
        [Fact]
        public async Task GetFolloweesOfNonExistentUser()
        {
            _handler = new GetFollowedUsersQueryHandler(_mockUnitOfWork.Object,_mapper);
            var result = await _handler.Handle(new GetFollowedUsersQuery() { Id = 100 }, CancellationToken.None);
            result.Value.ShouldBeEmpty();
        }
    }
}