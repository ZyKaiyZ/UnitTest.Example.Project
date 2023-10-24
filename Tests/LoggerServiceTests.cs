using UnitTest.Example.Models;
using UnitTest.Example.Services.Implementations;
using UnitTest.Example.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests
{
    public class LoggerServiceTests
    {
        private Mock<ILogger<LoggerService>>? _mcokLogger;

        private LoggerService CreateDefaultLoggerService()
        {
            _mcokLogger = new Mock<ILogger<LoggerService>>();
            return new LoggerService(_mcokLogger.Object);
        }

        [Fact]
        public void GetExampleModel_ReturnExampleModel()
        {
            // Arrange
            ILoggerService loggerService = CreateDefaultLoggerService();

            // Act
            ExampleModel result = loggerService.GetExampleModel();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Name);
            Assert.NotNull(result.Description);
            Assert.Equal("Example", result.Name);
            Assert.Equal("I am an example", result.Description);
            _mcokLogger.VerifyLog(logger => logger.LogInformation("Name: {0}, Description: {1}", result.Name, result.Description), Times.Once);
        }
    }
}
