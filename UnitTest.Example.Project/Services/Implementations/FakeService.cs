using UnitTest.Example.Models;
using UnitTest.Example.Project.Helper;
using UnitTest.Example.Services.Interfaces;

namespace UnitTest.Example.Services.Implementations
{
    public class FakeService : IFakeService
    {
        public ExampleModel GetExampleModel()
        {
            ExampleModel exampleModel = new ExampleModel()
            {
                Id = Guid.NewGuid(),
                Name = ExampleHelper.GetExampleName(),
                Description = DateTime.Now.ToString()
            };

            return exampleModel;
        }
    }
}
