using Application.Contracts.Persistence;
using Application.DTOs.Users;
using Application.Common.Exceptions;
using Application.features.Users.Handler.Command;
using Application.features.Users.Request.command;
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

namespace Application.Tests.Features.Users.Command
{
    public class FollowUserRequestHandlerUnitTest
    {

     
        private readonly Mock<IUserRepository> _mockRepo;
        public FollowUserRequestHandlerUnitTest()
        {
            _mockRepo = MockUserRepository.GetMockUserRepo();
        }


        [Fact]

        public async Task FollowUserRequest()
        {
            var handler = new FollowUserRequestHandler(_mockRepo.Object);
            var followDto = new FollowDto
            {
                FollowerId = 2,
                FolloweeId = 1
            };
            var result = await handler.Handle(
                new FollowUserRequest() { followDto = followDto} , CancellationToken.None
                );

            result.ShouldBe(true);



        }

        [Fact] 

        public async Task FollowUserRequest_ThrowBadRequest()
        {
            var handler = new FollowUserRequestHandler(_mockRepo.Object);
            var followDto = new FollowDto
            {
                FollowerId = 1,
                FolloweeId = 2
            };

            await Should.ThrowAsync<BadRequestException>(

                handler.Handle(new FollowUserRequest() { 
                
                followDto = followDto
                } , CancellationToken.None)  );

        }

        [Fact]
        public async Task FollowUserRequest_ThrowBadRequest2()
        {
            var handler = new FollowUserRequestHandler(_mockRepo.Object);
            var followDto = new FollowDto
            {
                FollowerId = 1,
                FolloweeId = 10
            };

            await Should.ThrowAsync<NotFoundException>(

                handler.Handle(new FollowUserRequest()
                {

                    followDto = followDto
                }, CancellationToken.None));

        }

    }
}
