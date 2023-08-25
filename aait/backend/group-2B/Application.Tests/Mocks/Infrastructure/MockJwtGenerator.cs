using Moq;
using SocialSync.Application.Contracts.Infrastructure;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Tests.Mocks;

public class MockJwtGenerator
{
    public static Mock<IJwtGenerator> GetMockJwtGenerator()
    {
        var jwtGenerator = new Mock<IJwtGenerator>();

        jwtGenerator.Setup(j => j.Generate(It.IsAny<User>())).Returns("token");

        return jwtGenerator;
    }
}
