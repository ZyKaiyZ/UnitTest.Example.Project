using UnitTest.Example.Models;
using UnitTest.Example.Services.Interfaces;

namespace UnitTest.Example.Services.Implementations
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger _logger;
        public LoggerService(ILogger<LoggerService> logger)
        {
            _logger = logger;
        }

        public ExampleModel GetExampleModel()
        {
            ExampleModel exampleModel = new ExampleModel()
            {
                Id = Guid.NewGuid(),
                Name = "Example",
                Description = "I am an example"
            };

            _logger.LogInformation("Name: {0}, Description: {1}", exampleModel.Name, exampleModel.Description);

            return exampleModel;
        }
    }
}
