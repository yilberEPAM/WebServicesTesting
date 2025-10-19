using RestSharp;
using Microsoft.Extensions.Configuration;

namespace WebServicesTesting.Helpers
{
    public class ApiClient : IApiClient
    {
        private readonly RestClient _client;

        public ApiClient()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var baseUrl = config["ApiBaseUrl"];
            _client = new RestClient(baseUrl);
        }

        public RestResponse Execute(RestRequest request)
        {
            return _client.Execute(request);
        }
    }
}
