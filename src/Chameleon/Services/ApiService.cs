namespace Chameleon.Services
{
    using Data.shared.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ApiService: IApiService
    {

        private readonly IHttpClientFactory _clientFactory;

        public List<Machine> Machines { get; set; }

        public bool GetMachinesError { get; private set; }

        public ApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


         async Task<List<Machine>> IApiService.OnGet(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "BlazorApp");

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response;
            try
            {
                response = await client.SendAsync(request);
               // response = await client.GetFromJsonAsync<List<Machine>>(url)
            }
            catch (Exception ex)
            {
                var b = ex;
                throw;
            }

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                    WriteIndented = true,
                };
                using var responseStream = await response.Content.ReadAsStreamAsync();
                 Machines = await System.Text.Json.JsonSerializer.DeserializeAsync
                    <List<Machine>>(responseStream);
            }
            else
            {
                GetMachinesError = true;
                Machines = new List<Machine>();
            }
            return Machines;
        }
       
    }
}
