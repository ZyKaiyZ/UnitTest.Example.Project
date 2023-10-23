using UnitTest.Example.Models;
using UnitTest.Example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IEnvironmentService _environmentService;
        private readonly ILoggerService _loggerService;
        private readonly IHttpService _httpService;

        public ExampleController(IEnvironmentService environmentService, ILoggerService loggerService, IHttpService httpService)
        {
            _environmentService = environmentService;
            _loggerService = loggerService;
            _httpService = httpService;
        }

        [HttpGet("GetExampleModel")]
        public IActionResult GetExampleModel()
        {
            ExampleModel exampleModel = new ExampleModel()
            {
                Id = Guid.NewGuid(),
                Name = "Example",
                Description = "I am an example"
            };

            return Ok(exampleModel);
        }

        [HttpGet("EnvironmentService/GetExampleModel")]
        public IActionResult GetExampleModelFromEnvironmentService()
        {
            return Ok(_environmentService.GetExampleModel());
        }

        [HttpGet("LoggerService/GetExampleModel")]
        public IActionResult GetExampleModelFromLoggerService()
        {
            return Ok(_loggerService.GetExampleModel());
        }

        [HttpGet("HttpService/GetExampleModel")]
        public async Task<IActionResult> GetExampleModelFromHttpServiceAsync()
        {
            return Ok(await _httpService.GetExampleModelAsync());
        }
    }
}