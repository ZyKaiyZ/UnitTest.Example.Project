using Moq;
using UnitTest.Example.Models;
using UnitTest.Example.Project.Repository.Interfaces;
using UnitTest.Example.Project.Services.Implementations;
using UnitTest.Example.Project.Services.Interfaces;
using UnitTest.Example.Services.Implementations;
using UnitTest.Example.Services.Interfaces;

namespace Tests
{
    public class AsyncServiceTests
    {
        private Mock<IExampleRepository>? _mockExampleRepository;
        private AsyncService CreateDefaultAsyncService()
        {
            _mockExampleRepository = new Mock<IExampleRepository>();
            return new AsyncService(_mockExampleRepository.Object);
        }

        [Fact]
        public async void GetExampleModel_ReturnExampleModel()
        {
            // Arrange
            IAsyncService asyncService = CreateDefaultAsyncService();

            var exampleModel = new ExampleModel
            {
                Name = "Example",
                Description = "I am an example"
            };

            _mockExampleRepository?.Setup(x => x.GetExampleModel()).ReturnsAsync(exampleModel);

            // Act
            ExampleModel result = await asyncService.GetExampleModel();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Name);
            Assert.NotNull(result.Description);
            Assert.Equal("Example", result.Name);
            Assert.Equal("I am an example", result.Description);
        }
    }
}
