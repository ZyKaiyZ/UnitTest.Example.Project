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
        public void GetExampleModel_ReturnExampleModel()
        {
            // Arrange
            IEnvironmentService environmentService = CreateDefaultEnvironmentService();

            // Act
            ExampleModel result = environmentService.GetExampleModel();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Name);
            Assert.NotNull(result.Description);
            Assert.Equal("Example", result.Name);
            Assert.Equal("I am an example", result.Description);
        }
    }
}
