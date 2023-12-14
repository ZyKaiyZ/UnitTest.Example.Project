using UnitTest.Example.Models;
using UnitTest.Example.Project.Repository.Interfaces;

namespace UnitTest.Example.Project.Repository.Implementations
{
    public class ExampleRepository : IExampleRepository
    {
        public Task<ExampleModel> GetExampleModel()
        {
            ExampleModel exampleModel = new ExampleModel()
            {
                Id = Guid.NewGuid(),
                Name = "Example",
                Description = "I am an example"
            };

            return Task.FromResult(exampleModel);
        }
    }
}
