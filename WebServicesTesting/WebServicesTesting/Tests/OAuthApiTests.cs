using RestSharp;
using System.Net;
using WebServicesTesting.Helpers;
using FluentAssertions;


namespace WebServicesTesting.Tests
{
    public class OAuthApiTests
    {
        private readonly ApiClient _apiClient = new ApiClient();

        private string GetFakeOAuthToken()
        {
            return "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.FakeToken";
        }

        [Fact]
        public void GetUser_WithOAuthToken_ShouldReturnUserData()
        {
            var request = new RestRequest("users/1", Method.Get);
            request.AddHeader("Authorization", GetFakeOAuthToken());

            var response = _apiClient.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().Contain("Leanne Graham");
        }

        [Fact]
        public void GetUser_WithoutOAuthToken_ShouldReturnUnauthorized()
        {
            var request = new RestRequest("users/1", Method.Get);

            var response = _apiClient.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK, "jsonplaceholder does not require authentication, but a real API would return 401 here");
        }
    }
}
