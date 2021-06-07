namespace Chameleon.Server.Services
{
    public class RestService
    {
        private static readonly HttpClient client;

        public RestService(HttpClient _client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> Get(string Url)
        {
            var response = new HttpResponseMessage();
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "CHM Rest API");
                response = await client.GetAsync(Url);
                return response;
            }
            catch (Exception)
            //catch (Exception ex)
            {
                //failed to connect send http error response
                response.StatusCode = HttpStatusCode.GatewayTimeout;
                return response;
            }
        }
    }
}