using Newtonsoft.Json;
using RestSharp;
using System.Net;
using WebServicesTesting.Helpers;
using WebServicesTesting.Models;
using FluentAssertions;
using NSubstitute;

namespace WebServicesTesting.Tests
{
    public class UserApiMockTests
    {
        [Fact]
        public void GetUser_ShouldReturnMockedUser()
        {
            var mockClient = Substitute.For<IApiClient>();
            var fakeUser = new UserModel
            {
                Id = 99,
                Name = "Mocked User",
                Username = "mockeduser",
                Email = "mocked@user.com"
            };
            var fakeResponse = new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonConvert.SerializeObject(fakeUser)
            };

            mockClient.Execute(Arg.Any<RestRequest>()).Returns(fakeResponse);

            var request = new RestRequest("users/99", Method.Get);
            var response = mockClient.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var user = JsonConvert.DeserializeObject<UserModel>(response.Content);
            user.Name.Should().Be("Mocked User");
            user.Email.Should().Be("mocked@user.com");
        }

        [Fact]
        public void GetUser_ShouldReturnNotFound()
        {
            var mockClient = Substitute.For<IApiClient>();
            var fakeResponse = new RestResponse
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = ""
            };

            mockClient.Execute(Arg.Any<RestRequest>()).Returns(fakeResponse);

            var request = new RestRequest("users/404", Method.Get);
            var response = mockClient.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
