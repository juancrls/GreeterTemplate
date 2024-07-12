using Greeter.Domain.Interfaces.Repositories.Greetings;
using Greeter.Grpc.Services;
using Greeter.Grpc;
using Grpc.Core;
using Moq;
using NUnit.Framework;

namespace Greeter.Tests.UnitTests.Services
{
    public class GreetingsGrpcServiceTests
    {
        [Test]
        public async Task SayHelloAsync_ShouldReturnGreetingsString_WhenCalledCorrectlyViaGrpcWeb()
        {
            // Arrange
            var mockGreetingsRepository = new Mock<IGreetingsRepository>();

            mockGreetingsRepository.Setup(repo => repo.FindGreetingsMessageAsync()).ReturnsAsync("Hello!");

            var greetingsGrpcService = new GreetingsGrpcService(mockGreetingsRepository.Object);

            // Act
            var result = await greetingsGrpcService.SayHelloAsync();

            // Assert
            Assert.AreEqual("Hello! | This message was proccessed by the gRPC service layer!", result.Message);
        }

        [Test]
        public async Task SayHelloAsync_ShouldReturnGreetingsString_WhenCalledCorrectlyViaGrpcNative()
        {
            // Arrange
            var mockGreetingsRepository = new Mock<IGreetingsRepository>();

            mockGreetingsRepository.Setup(repo => repo.FindGreetingsMessageAsync()).ReturnsAsync("Hello!");

            var mockServerCallContext = new Mock<ServerCallContext>();
            var emptyRequest = new Empty();

            var greetingsGrpcService = new GreetingsGrpcService(mockGreetingsRepository.Object);

            // Act
            var result = await greetingsGrpcService.SayHelloAsync(emptyRequest, mockServerCallContext.Object);

            // Assert
            Assert.AreEqual("Hello! | This message was proccessed by the gRPC service layer!", result.Message);
        }
    }
}