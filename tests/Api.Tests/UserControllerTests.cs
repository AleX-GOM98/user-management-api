using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace UserManagementApi.Tests
{
    public class UserControllerTests : IClassFixture<WebApplicationFactory<UserManagementApi.Program>> // Certifique-se de usar o nome correto para o Program.cs da API
    {
        private readonly HttpClient _client;

        public UserControllerTests(WebApplicationFactory<UserManagementApi.Program> factory) // Nome correto da classe Program
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Test_Create_User()
        {
            var newUser = new
            {
                Name = "John Doe",
                Email = "johndoe@example.com",
                Age = 30
            };

            var jsonContent = JsonConvert.SerializeObject(newUser);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/users", content);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Test_Get_Users()
        {
            var response = await _client.GetAsync("/users");

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.Contains("John Doe", responseBody);
        }
    }
}
