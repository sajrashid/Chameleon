namespace Chameleon.Client.Services
{
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ApiService<T> : IApiService<T> where T : class
    {
        private readonly HttpClient _clientFactory;

        public ApiService(HttpClient clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> OnGet(string url)
        {
            T result = null;
            using (_clientFactory)
            {
                var response = _clientFactory.GetAsync(new Uri(url)).Result;
                response.EnsureSuccessStatusCode();
                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;
                    result = JsonSerializer.Deserialize<T>(x.Result);
                });
            }
            return result;
        }
    }
}