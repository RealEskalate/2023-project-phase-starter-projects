using Application.Contracts;
using Application.DTO.FollowDTo;
using Application.DTO.UserDTO.DTO;
using Application.Features.FollowFeature.Handlers.Queries;
using Application.Features.FollowFeature.Requests.Queries;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using Application.Tests.Mocs;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.FollowFeature.Commands
{
    public class GetFollowersQueryTest
    {            
            private readonly Mock<IUnitOfWork> _mockUnitOfWork;    
            private readonly IMapper _mapper;
            private readonly FollowDTO _followDTO;
            private  GetFollowersQueryHandler _handler;
            public GetFollowersQueryTest()
            {
                _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

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

            _handler = new GetFollowersQueryHandler(_mockUnitOfWork.Object,_mapper);
                         
            var result = await _handler.Handle(new GetFollowersQuery() { Id = 2 }, CancellationToken.None);
            result.Value.Count().ShouldBe(1);
            result.ShouldBeOfType<BaseResponse<List<UserResponseDTO>>>();
        }
        
        [Fact]
        public async Task GetFollowersOfNonExistentUser()
        {

            _handler = new GetFollowersQueryHandler(_mockUnitOfWork.Object,_mapper);
            var result = await _handler.Handle(new GetFollowersQuery() { Id = 100 }, CancellationToken.None);
            result.Value.ShouldBeEmpty();
        }
        public async Task GetFollowersWithOfRangeId()
        {

            _handler = new GetFollowersQueryHandler(_mockUnitOfWork.Object,_mapper);
            var result = await _handler.Handle(new GetFollowersQuery() { Id = -100 }, CancellationToken.None);
            result.Value.ShouldBeEmpty();
        }
    }
}