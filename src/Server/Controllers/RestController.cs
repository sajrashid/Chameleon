namespace Chameleon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {
        private readonly ILogger<RestController> _logger;
        private readonly RestService _restService;

        public RestController(ILogger<RestController> logger, RestService restService)
        {
            _restService = restService;
            _logger = logger;
        }

        // GET: api/<httpController>
        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            _logger.LogInformation("Sending get to IP ???TBD");
            string url = "http://192.168.0.69/printer/info";
            var response = await _restService.Get(url);
            return response;
        }

        // GET api/<httpController>/5
        [HttpGet("{url}")]
        public string Get(string url)
        {
            return "value";
        }

        // POST api/<httpController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<httpController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<httpController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}