using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Users;
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
    public class UnFollowUserRequestHandlerUnitTest
    {

    
        private readonly Mock<IUserRepository> _mockRepo;
        public UnFollowUserRequestHandlerUnitTest()
        {
            _mockRepo = MockUserRepository.GetMockUserRepo();

           
        }


        [Fact]
        public async Task UnFollowUserTest()
        {
            var handler = new UnfollowUserRequestHandler(_mockRepo.Object);

            var followDto = new FollowDto
            {
                FollowerId = 1,
                FolloweeId = 2
            };
            var result = await handler.Handle(new UnfollowUserRequest() { followDto = followDto } , CancellationToken.None);

            result.ShouldBe(true);
        }

        [Fact]
        public async Task UnFollowUser_ThrowBadRequestException()
        {
            var handler = new UnfollowUserRequestHandler(_mockRepo.Object);

            var followDto = new FollowDto
            {
                FollowerId = 2,
                FolloweeId = 1
            };

            await Should.ThrowAsync<BadRequestException>(handler.Handle(

                new UnfollowUserRequest() { followDto = followDto }, CancellationToken.None));
        }


    }
}
