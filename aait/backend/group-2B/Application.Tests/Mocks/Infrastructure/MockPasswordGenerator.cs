using Moq;
using SocialSync.Application.Contracts.Infrastructure;

namespace SocialSync.Application.Tests.Mocks;

public class MockPasswordHasher
{
    public static Mock<IPasswordHasher> GetMockPasswordHasher()
    {
        var mockPasswordHasher = new Mock<IPasswordHasher>();

        mockPasswordHasher.Setup(p => p.HashPassword(It.IsAny<string>())).Returns("hashedPassword");
        mockPasswordHasher
            .Setup(p => p.VerifyPassword(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        return mockPasswordHasher;
    }
}
