using UnitTest.Example.Models;

namespace UnitTest.Example.Project.Services.Interfaces
{
    public interface IAsyncService
    {
        Task<ExampleModel> GetExampleModel();
    }
}
