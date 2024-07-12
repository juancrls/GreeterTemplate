using Greeter.Application.Services;
using Greeter.Domain.Interfaces.Repositories.Greetings;
using Moq;
using NUnit.Framework;

namespace Greeter.Tests.UnitTests.Services
{
    public class GreetingsServiceTests
    {
        [Test]
        public async Task GetGreetingsMessageAsync_ShouldReturnGreetingsString_WhenCalledCorrectly()
        {
            // Arrange
            var mockGreetingsRepository = new Mock<IGreetingsRepository>();

            mockGreetingsRepository.Setup(repo => repo.FindGreetingsMessageAsync()).ReturnsAsync("Hello!");

            var greetingsService = new GreetingsService(mockGreetingsRepository.Object);

            // Act
            var result = await greetingsService.GetGreetingsMessageAsync();

            // Assert
            Assert.AreEqual("Hello! | This message was proccessed by the service layer!", result);
        }
    }
}