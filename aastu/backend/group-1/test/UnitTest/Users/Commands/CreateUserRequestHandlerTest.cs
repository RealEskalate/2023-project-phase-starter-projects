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




namespace test.UnitTest.Users.Commands
{
    public class CreateUserRequestHandlerTest
    {
            private  readonly IMapper _mapper;
            private readonly Mock<IUserRepository> _mockRepoUser;
            private readonly CreateUsersRequestHandler _handler;
            
            private readonly CreateUserDto _createUserDto;

        public CreateUserRequestHandlerTest()
        {
            
            _mockRepoUser = MockRepositoryFactory.GetUserRepository();
            _handler = new CreateUsersRequestHandler(_mockRepoUser.Object, _mapper);


            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();  
    

    /* public string? Name { get; set; }
    public string? email { get; set; }
    public string? Bio { get; set; }
    public string? password { get; set; }*/
            _createUserDto = new CreateUserDto
            {
                Name = "Jima Dube",
                email = "jima@gmail.com",
                Bio = "I like the picture:)",
            };
        }

        [Fact]
        public async Task createUser()
        {
        
            var result = await _handler.Handle(new CreateUserRequest(){ CreateUserDto = _createUserDto}, CancellationToken.None);
            
            var users = await _mockRepoUser.Object.GetAll();
            
            result.ShouldBeOfType<BaseResponseClass>();
            users.Count.ShouldBe(2);
        }

    }
}