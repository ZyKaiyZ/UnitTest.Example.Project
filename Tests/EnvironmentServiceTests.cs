using UnitTest.Example.Models;
using UnitTest.Example.Services.Implementations;
using UnitTest.Example.Services.Interfaces;

namespace Tests
{
    public class EnvironmentServiceTests
    {
        private EnvironmentService CreateDefaultEnvironmentService()
        {
            return new EnvironmentService();
        }

        [Fact]
        public void GetExampleModelTest()
        {
            IEnvironmentService environmentService = CreateDefaultEnvironmentService();

            ExampleModel exampleModel = environmentService.GetExampleModel();

            Assert.NotNull(exampleModel);
            Assert.NotNull(exampleModel.Name);
            Assert.NotNull(exampleModel.Description);
            Assert.Equal("Example", exampleModel.Name);
            Assert.Equal("I am an example", exampleModel.Description);
        }
    }
}
