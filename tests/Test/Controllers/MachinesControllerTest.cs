using Chameleon.Shared;
using Microsoft.AspNetCore.Mvc.Testing;
using Chameleon.Server;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using System.Collections.Generic;
namespace Test
{
    public class MachinesControllerTest
        : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public MachinesControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("/api/machines")]
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
            List<Machine> MachinesList = JsonSerializer.Deserialize<List<Machine>>(stringResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            Assert.IsType<List<Machine>>(MachinesList);
            Assert.NotEmpty(MachinesList);
            Assert.True(MachinesList.Count > 0);
        }
    }
}
