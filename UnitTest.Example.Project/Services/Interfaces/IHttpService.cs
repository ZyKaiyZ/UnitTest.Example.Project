using UnitTest.Example.Models;

namespace UnitTest.Example.Services.Interfaces
{
    public interface IHttpService
    {
        Task<ExampleModel?> GetExampleModelAsync();
    }
}
