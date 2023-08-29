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
    public class CreateFollowCommandTest
    {            
            private readonly IMapper _mapper;
            private readonly FollowDTO _followDTO;
            private  CreateFollowCommandHandler _handler;
            public CreateFollowCommandTest()
            {

                var mapperConfig = new MapperConfiguration(c => 
                {
                    c.AddProfile<MappingProfile>();
                });

                _mapper = mapperConfig.CreateMapper();
               
                

                _followDTO = new FollowDTO
                {
                    FolloweeId = 1,
                    FollowerId = 3
                };
            }

        [Fact]
        public async Task Valid_Follow_Added()
        {
            var mocFollowRepository = MockFollowRepository.GetFollowRepository().Object;
            var mockUserRepository = MockUserRepository.GetUserRepository().Object;
            _handler = new CreateFollowCommandHandler(_mapper,mocFollowRepository,mockUserRepository);
                         
            var result = await _handler.Handle(new CreateFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None);
            var Follows = await mocFollowRepository.GetAll();
            Follows.Count().ShouldBe(4);
            result.ShouldBeOfType<BaseResponse<int>>();
        }

        [Fact]
        public async Task FollowWithIdOutOfRange()
        {
             var mocFollowRepository = MockFollowRepository.GetFollowRepository().Object;
            var mockUserRepository = MockUserRepository.GetUserRepository().Object;
            _handler = new CreateFollowCommandHandler(_mapper,mocFollowRepository,mockUserRepository);
            _followDTO.FolloweeId = -1;

           await Should.ThrowAsync<BadRequestException>(async () =>
                await _handler.Handle(new CreateFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None));
        }

        [Fact]
        public async Task NonExistentFollowee()
        {
             var mocFollowRepository = MockFollowRepository.GetFollowRepository().Object;
            var mockUserRepository = MockUserRepository.GetUserRepository().Object;
            _handler = new CreateFollowCommandHandler(_mapper,mocFollowRepository,mockUserRepository);
            _followDTO.FolloweeId = 100;

            await Should.ThrowAsync<BadRequestException>(async () =>
                await _handler.Handle(new CreateFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None));

            // var result = await _handler.Handle(new CreateFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None);
            // var Follows = await mocFollowRepository.GetAll();
            // Follows.Count.ShouldBe(3);

            
            // result.ShouldBeOfType<BaseResponse<Follow>>();
        }
    }
}