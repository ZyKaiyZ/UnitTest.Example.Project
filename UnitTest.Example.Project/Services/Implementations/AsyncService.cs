using UnitTest.Example.Models;
using UnitTest.Example.Project.Repository.Interfaces;
using UnitTest.Example.Project.Services.Interfaces;

namespace UnitTest.Example.Project.Services.Implementations
{
    public class AsyncService : IAsyncService
    {
        private readonly IExampleRepository _exampleRepository;

        public AsyncService(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<ExampleModel> GetExampleModel()
        {
            ExampleModel exampleModel = await _exampleRepository.GetExampleModel();

            return exampleModel;
        }
    }
}
