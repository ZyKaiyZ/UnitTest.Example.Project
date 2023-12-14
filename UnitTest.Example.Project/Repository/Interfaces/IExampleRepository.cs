using UnitTest.Example.Models;

namespace UnitTest.Example.Project.Repository.Interfaces
{
    public interface IExampleRepository
    {
        Task<ExampleModel> GetExampleModel();
    }
}
