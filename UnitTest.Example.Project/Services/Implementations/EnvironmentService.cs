using UnitTest.Example.Models;
using UnitTest.Example.Services.Interfaces;

namespace UnitTest.Example.Services.Implementations
{
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentService() { }

        public ExampleModel GetExampleModel()
        {
            ExampleModel exampleModel = new ExampleModel()
            {
                Id = Guid.NewGuid(),
                Name = Environment.GetEnvironmentVariable("EXAMPLE_NAME"),
                Description = Environment.GetEnvironmentVariable("EXAMPLE_DESCRIPTION")
            };

            return exampleModel;
        }
    }
}
