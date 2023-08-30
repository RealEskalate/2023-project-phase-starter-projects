using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.DTO.Common;
using Application.DTO.FollowDTo;
using Application.DTO.UserDTO.DTO;
using Application.Features.FollowFeature.Handlers.Commands;
using Application.Features.FollowFeature.Handlers.Queries;
using Application.Features.FollowFeature.Requests.Commands;
using Application.Features.FollowFeature.Requests.Queries;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocs;
using AutoMapper;
using Domain.Entites;
using Moq;
using Shouldly;

namespace Application.Tests.Features.FollowFeature.Commands
{
    public class GetFollowedUsersQueryTest
    {            
            private readonly IMapper _mapper;
            private readonly FollowDTO _followDTO;
            private  GetFollowedUsersQueryHandler _handler;
            public GetFollowedUsersQueryTest()
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
        public async Task GetFolloweesOfValidUser()
        {
            var mocFollowRepository = MockFollowRepository.GetFollowRepository().Object;
            var mockUserRepository = MockUserRepository.GetUserRepository().Object;
            _handler = new GetFollowedUsersQueryHandler(mocFollowRepository,_mapper);
                         
            var result = await _handler.Handle(new GetFollowedUsersQuery() { Id = 2 }, CancellationToken.None);
            result.Value.Count().ShouldBe(1);
            result.ShouldBeOfType<BaseResponse<List<UserResponseDTO>>>();
        }
        
        [Fact]
        public async Task GetFolloweesOfNonExistentUser()
        {
             var mocFollowRepository = MockFollowRepository.GetFollowRepository().Object;
            var mockUserRepository = MockUserRepository.GetUserRepository().Object;
            _handler = new GetFollowedUsersQueryHandler(mocFollowRepository,_mapper);
            var result = await _handler.Handle(new GetFollowedUsersQuery() { Id = 100 }, CancellationToken.None);
            result.Value.ShouldBeEmpty();
        }
    }
}