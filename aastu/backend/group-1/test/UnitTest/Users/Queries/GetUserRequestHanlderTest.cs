using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Features.Users.Handler.Queries;
using SocialMediaApp.Application.Features.Users.Request.Queries;
using SocialMediaApp.Application.DTOs.Users;
using SocialMediaApp.Application.Profiles;   
using Shouldly;
using test.UnitTest.Mocks;


namespace test.UnitTest.Users.Queries
{
    public class GetUserRequestHanlderTest
  {
            private  readonly IMapper _mapper;
            private readonly Mock<IUserRepository> _mockRepo;

            public GetUserRequestHanlderTest()
            {
            _mockRepo = MockRepositoryFactory.GetUserRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();  
            }


            [Fact]
            public async Task GetUserListTest()
            {
                var handler = new GetUsersRequestHandler(_mockRepo.Object, _mapper);

                var result = await handler.Handle(new GetUsersRequest(), CancellationToken.None);

                result.ShouldBeOfType<List<UserDto>>();
                result.Count.ShouldBe(2);
            }
        
    }
}