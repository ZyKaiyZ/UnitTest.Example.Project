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
        public void GetExampleModelTest()
        {
            ILoggerService loggerService = CreateDefaultLoggerService();

            ExampleModel exampleModel = loggerService.GetExampleModel();

            Assert.NotNull(exampleModel);
            Assert.NotNull(exampleModel.Name);
            Assert.NotNull(exampleModel.Description);
            Assert.Equal("Example", exampleModel.Name);
            Assert.Equal("I am an example", exampleModel.Description);
            _mcokLogger.VerifyLog(logger => logger.LogInformation("Name: {0}, Description: {1}", exampleModel.Name, exampleModel.Description), Times.Once);
        }
    }
}
