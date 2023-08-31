using Application.Features.Users.Handlers.Queries;
using Application.Features.Users.Requests.Queries;
using AutoMapper;
using HRLeaveManagement.Application.Profiles;
using Moq;
using Shouldly;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Authentication.Handlers.Commands;

public class GetUserQueryRequestHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly GetUserQueryRequestHandler _handler;

    public GetUserQueryRequestHandlerTest()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<AuthenticationMappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        _handler = new GetUserQueryRequestHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task Valid_GetUser()
    {
        var result = await _handler.Handle(
            new GetUserQuerieRequest { Id = 1 },
            CancellationToken.None
        );

        result.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public async Task Invalid_GetUser()
    {
        var result = await _handler.Handle(
            new GetUserQuerieRequest { Id = 1000 },
            CancellationToken.None
        ); // we only have 3 users in the user repository

        result.IsSuccess.ShouldBeFalse();
    }
}
