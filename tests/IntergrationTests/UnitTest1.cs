using Chameleon.Server;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace IntergrationTests
{
    public class BasicTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BasicTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/api/blah")]
        [InlineData("/FetchData")]
        [InlineData("/api/machines")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            var clientOptions = new WebApplicationFactoryClientOptions();

            // Arrange
            var client = _factory.CreateClient();
            Console.WriteLine(url);
            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
          response.Content.Headers.ContentType.ToString());
        }
    }
}