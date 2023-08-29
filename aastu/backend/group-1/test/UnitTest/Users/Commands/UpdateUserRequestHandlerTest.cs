using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.UnitTest.Mocks;
using AutoMapper;
using Moq;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Features.Users.Handler.Commands;
using SocialMediaApp.Application.Features.Users.Request.Commands;
using SocialMediaApp.Application.DTOs.Users;
using SocialMediaApp.Application.Responses;
using SocialMediaApp.Application.Profiles;   
using Shouldly;
using SocialMediaApp.Application.Features.Users.Handler.Commands;
using SocialMediaApp.Application.Features.Users.Request.Commands;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Users.Handler.Commands;
using SocialMediaApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.DTOs.Users.Validations;
using Microsoft.Extensions.Hosting;

namespace test.UnitTest.Users.Commands
{
    public class UpdateUserRequestHandlerTest
    {


        [Fact]
        public async Task UpdateuserTest()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    Name = "Jima Dube",
                    email = "jimd@gmail.com",
                    password = "High123@",
                },
                new User
                {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc6"),
                    Name = "xBebe",
                    email = "bebe@gmail.com",
                    password = "bebe123#",
                }
            };


            // Arrange
            var userId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc6");
            var updateUserDto = new UpdateUserDto
            {
                Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc6"),
                Name = "Jima Dube",
                email = "jima@gmail.com",
                Bio = "I like the picture:)"
            };

            var mockUserRepository = new Mock<IUserRepository>();

            var mockMapper = new Mock<IMapper>();

            // Configure mock behavior (replace this with your actual behavior)

            mockUserRepository.Setup(p => p.Add(users[1])).ReturnsAsync(users[1]);
            // mockUserRepository.Setup(repo => repo.GetAll()).ReturnsAsync(() => users);

            var handler = new UpdateUserCommandRequestHandler(mockUserRepository.Object, mockMapper.Object);

            var request = new UpdateUserCommandRequest { UpdateUserDto = updateUserDto };
            var validator = new ValidateUpdateUserDto(mockUserRepository.Object);
            var validationResult = await validator.ValidateAsync(updateUserDto);
            
            // Act & Assert
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.IsType<Unit>(result);
            Assert.True(validationResult.IsValid);


        } 
    }
}