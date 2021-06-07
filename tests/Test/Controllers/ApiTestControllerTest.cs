using System;
using System.Text.Json;
using System.Threading.Tasks;

using Chameleon.Server;
using Chameleon.Shared;

using Microsoft.AspNetCore.Mvc.Testing;

using Xunit;

namespace Test
{
    public class ApiTestControllerTest
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ApiTestControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/apitest")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            Console.WriteLine(url);
            // Act
            var response = await client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            //var stringResponse = JsonSerializer.Deserialize<Machine[]>(await response.Content.ReadAsStringAsync());
            var Hello = JsonSerializer.Deserialize<HelloWorld>(stringResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            Assert.IsType<HelloWorld>(Hello);
            Assert.NotEmpty(Hello.Greetings);
        }
    }
}