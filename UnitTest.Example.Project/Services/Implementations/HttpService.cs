using UnitTest.Example.Models;
using UnitTest.Example.Services.Interfaces;
using Newtonsoft.Json;

namespace UnitTest.Example.Services.Implementations
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
                
        public HttpService(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ExampleModel?> GetExampleModelAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7182/api/Example/GetExampleModel");
            var exampleModel = new ExampleModel();

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                exampleModel = JsonConvert.DeserializeObject<ExampleModel>(jsonResponse);
            }

            return exampleModel;
        }
    }
}
