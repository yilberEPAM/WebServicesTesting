using Newtonsoft.Json;
using RestSharp;
using WebServicesTesting.Helpers;
using WebServicesTesting.Models;
using FluentAssertions;

namespace WebServicesTesting.Tests
{
    public class UserApiTests
    {
        private readonly ApiClient _apiClient = new ApiClient();

        [Fact]
        public void GetUser_ShouldReturnUserData()
        {
            var request = new RestRequest("users/1", Method.Get);
            var response = _apiClient.Execute(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var user = JsonConvert.DeserializeObject<UserModel>(response.Content);
            user.Should().NotBeNull();
            user.Id.Should().Be(1);
        }

        [Fact]
        public void GetAllUsers_ShouldReturnListOfUsers()
        {
            var request = new RestRequest("users", Method.Get);
            var response = _apiClient.Execute(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);
            users.Should().NotBeNull();
            users.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void CreateUser_ShouldReturnCreatedUser()
        {
            var request = new RestRequest("users", Method.Post);
            request.AddJsonBody(new
            {
                name = "Nuevo Usuario",
                username = "nuevo_usuario",
                email = "nuevo@usuario.com"
            });

            var response = _apiClient.Execute(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            var user = JsonConvert.DeserializeObject<UserModel>(response.Content);
            user.Should().NotBeNull();
            user.Name.Should().Be("Nuevo Usuario");
            user.Username.Should().Be("nuevo_usuario");
            user.Email.Should().Be("nuevo@usuario.com");
        }

        [Fact]
        public void UpdateUser_ShouldReturnUpdatedUser()
        {
            var request = new RestRequest("users/1", Method.Put);
            request.AddJsonBody(new
            {
                id = 1,
                name = "Usuario Actualizado",
                username = "usuario_actualizado",
                email = "actualizado@usuario.com"
            });

            var response = _apiClient.Execute(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var user = JsonConvert.DeserializeObject<UserModel>(response.Content);
            user.Should().NotBeNull();
            user.Name.Should().Be("Usuario Actualizado");
            user.Username.Should().Be("usuario_actualizado");
            user.Email.Should().Be("actualizado@usuario.com");
        }

        [Fact]
        public void DeleteUser_ShouldReturnSuccess()
        {
            var request = new RestRequest("users/1", Method.Delete);
            var response = _apiClient.Execute(request);

            // La API responde con 200 OK aunque no borra realmente el usuario
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Content.Should().Be("{}");
        }

    }
}
