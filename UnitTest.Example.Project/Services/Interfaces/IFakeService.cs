using UnitTest.Example.Models;
using UnitTest.Example.Services.Implementations;

namespace UnitTest.Example.Services.Interfaces
{
    public interface IFakeService
    {
        ExampleModel GetExampleModel();
    }
}
