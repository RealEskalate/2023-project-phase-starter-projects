using Application.DTO;
using Application.DTO.FollowDTo;
using Application.DTO.UserDTO.DTO;
using Application.Features.FollowFeature.Handlers.Queries;
using Application.Features.FollowFeature.Requests.Queries;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocs;
using AutoMapper;
using Shouldly;

namespace Application.Tests.Features.FollowFeature.Commands
{
    public class GetFollowersQueryTest
    {            
            private readonly IMapper _mapper;
            private readonly FollowDTO _followDTO;
            private  GetFollowersQueryHandler _handler;
            public GetFollowersQueryTest()
            {

                var mapperConfig = new MapperConfiguration(c => 
                {
                    c.AddProfile<MappingProfile>();
                });

                _mapper = mapperConfig.CreateMapper();
               
                _followDTO = new FollowDTO
                {
                    FolloweeId = 3,
                    FollowerId = 1
                };
            }

        [Fact]
        public async Task GetFollowersOfValidUser()
        {
            var mocFollowRepository = MockFollowRepository.GetFollowRepository().Object;
            var mockUserRepository = MockUserRepository.GetUserRepository().Object;
            _handler = new GetFollowersQueryHandler(mocFollowRepository,_mapper);
                         
            var result = await _handler.Handle(new GetFollowersQuery() { Id = 2 }, CancellationToken.None);
            result.Value.Count().ShouldBe(1);
            result.ShouldBeOfType<BaseResponse<List<UserResponseDTO>>>();
        }
        
        [Fact]
        public async Task GetFollowersOfNonExistentUser()
        {
             var mocFollowRepository = MockFollowRepository.GetFollowRepository().Object;
            var mockUserRepository = MockUserRepository.GetUserRepository().Object;
            _handler = new GetFollowersQueryHandler(mocFollowRepository,_mapper);
            var result = await _handler.Handle(new GetFollowersQuery() { Id = 100 }, CancellationToken.None);
            result.Value.ShouldBeEmpty();
        }
        public async Task GetFollowersWithOfRangeId()
        {
             var mocFollowRepository = MockFollowRepository.GetFollowRepository().Object;
            var mockUserRepository = MockUserRepository.GetUserRepository().Object;
            _handler = new GetFollowersQueryHandler(mocFollowRepository,_mapper);
            var result = await _handler.Handle(new GetFollowersQuery() { Id = -100 }, CancellationToken.None);
            result.Value.ShouldBeEmpty();
        }
    }
}