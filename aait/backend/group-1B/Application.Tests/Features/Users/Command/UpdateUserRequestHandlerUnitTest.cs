using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Users;
using Application.features.Users.Handler.Command;
using Application.features.Users.Request.command;
using Application.Profiles;
using Application.Tests.Mocks;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Features.Users.Command
{
    public class UpdateUserRequestHandlerUnitTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockRepo;
        public UpdateUserRequestHandlerUnitTest()
        {
            _mockRepo = MockUserRepository.GetMockUserRepo();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async Task UpdateUserHandlerTest()
        {

            var handler = new UpdateUserRequestHandler(_mockRepo.Object, _mapper);

            var updateUserDto = new UpdateUserDto()
            {
                Id = 1,
                FirstName = "Updated first name",
                LastName = "Updated last name",
                Bio = "updated Bio"


            };

             var result = await handler.Handle(
                new UpdateUserRequest() { UpdateUserDto = updateUserDto }, CancellationToken.None);

            result.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task UpdateUserHandler_ThrowNotFoundException()
        {
            var handler = new UpdateUserRequestHandler(_mockRepo.Object, _mapper);

            var updateUserDto = new UpdateUserDto()
            {
                Id = 4,
                FirstName = "Updated first name",
                LastName = "Updated last name",
                Bio = "updated Bio"


            };

            await Should.ThrowAsync<BadRequestException>(handler.Handle(

                new UpdateUserRequest() { UpdateUserDto = updateUserDto },
                CancellationToken.None
                ));
        }
    }
}
