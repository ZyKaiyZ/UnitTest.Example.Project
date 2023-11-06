using Microsoft.QualityTools.Testing.Fakes;
using UnitTest.Example.Models;
using UnitTest.Example.Services.Implementations;
using UnitTest.Example.Services.Interfaces;

namespace Tests
{
    public class FakeServiceTests
    {
        private FakeService CreateDefaultFakeService()
        {
            return new FakeService();
        }

        [Fact]
        public void GetExampleModel_ReturnExampleModel()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                IFakeService fakeService = CreateDefaultFakeService();

                UnitTest.Example.Project.Helper.Fakes.ShimExampleHelper.GetExampleName = () =>
                {
                    return "Example";
                };

                System.Fakes.ShimDateTime.NowGet = () =>
                {
                    return new DateTime(1000, 1, 1);
                };

                // Act
                ExampleModel result = fakeService.GetExampleModel();

                // Assert
                Assert.NotNull(result);
                Assert.NotNull(result.Name);
                Assert.NotNull(result.Description);
                Assert.Equal("Example", result.Name);
                Assert.Equal("1000/1/1 上午 12:00:00", result.Description);
            }
        }
    }
}
