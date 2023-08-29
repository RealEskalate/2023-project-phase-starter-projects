using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.Common;
using Application.DTO.FollowDTo;
using Application.Exceptions;
using Application.Features.FollowFeature.Handlers.Commands;
using Application.Features.FollowFeature.Requests.Commands;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocs;
using AutoMapper;
using Domain.Entites;
using Moq;
using Shouldly;

namespace Application.Tests.Features.FollowFeature.Commands
{
    public class DeleteFollowCommandTest
    {            
            private readonly IMapper _mapper;
            private readonly FollowDTO _followDTO;
            private  DeleteFollowCommandHandler _handler;
            public DeleteFollowCommandTest()
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
        public async Task ValidFollowDelete()
        {
            var mocFollowRepository = MockFollowRepository.GetFollowRepository().Object;
            var mockUserRepository = MockUserRepository.GetUserRepository().Object;
            _handler = new DeleteFollowCommandHandler(_mapper,mocFollowRepository,mockUserRepository);
                         
            var result = await _handler.Handle(new DeleteFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None);
            var Follows = await mocFollowRepository.GetAll();
            Follows.Count().ShouldBe(2);
            result.ShouldBeOfType<BaseResponse<int>>();
        }

        
        [Fact]
        public async Task DeleteNonExistentFollow()
        {
             var mocFollowRepository = MockFollowRepository.GetFollowRepository().Object;
            var mockUserRepository = MockUserRepository.GetUserRepository().Object;
            _handler = new DeleteFollowCommandHandler(_mapper,mocFollowRepository,mockUserRepository);
            _followDTO.FolloweeId = 100;
            await Should.ThrowAsync<BadRequestException>(async () =>
                await _handler.Handle(new DeleteFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None));
        }
    }
}