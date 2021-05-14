namespace Chameleon.Services
{

    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    public class ApiService<T> : IApiService<T> where T : class
    {

        private readonly IHttpClientFactory _clientFactory;

        public ApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> OnGet(string url)
        {
            T result = null;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(new Uri(url)).Result;
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