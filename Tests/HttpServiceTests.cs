using Moq;
using RichardSzalay.MockHttp;
using System.Net;
using System.Xml.Linq;
using UnitTest.Example.Models;
using UnitTest.Example.Services.Implementations;
using UnitTest.Example.Services.Interfaces;

namespace Tests
{
    public class HttpServiceTests
    {
        private Mock<IHttpClientFactory>? _mockHttpClientFactory;
        private HttpService CreateDefaultHttpService()
        {
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            return new HttpService(_mockHttpClientFactory.Object);
        }

        [Fact]
        public async void GetExampleModelTest()
        {
            // Arrange
            IHttpService httpService = CreateDefaultHttpService();

            string exampleModelJson = "{'Id' : '00000000-0000-0000-0000-000000000000', 'Name' : 'Example', 'Description' : 'I am an example' }";

            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(HttpMethod.Get, "*/api/Example/GetExampleModel").Respond("application/json", exampleModelJson);
            _mockHttpClientFactory?.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(mockHttp.ToHttpClient());

            // Act
            ExampleModel? result = await httpService.GetExampleModelAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Name);
            Assert.NotNull(result.Description);
            Assert.Equal("Example", result.Name);
            Assert.Equal("I am an example", result.Description);
            mockHttp.VerifyNoOutstandingExpectation();
            _mockHttpClientFactory?.Verify(factory => factory.CreateClient(It.IsAny<string>()), Times.Once);
            Assert.Equal(1, mockHttp.GetMatchCount(request));
        }
    }
}
