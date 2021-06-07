namespace Chameleon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocketController : ControllerBase
    {// GET: api/<SocketController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var context = HttpContext;

            //if (context.Request.Path == "/ws")
            //{
            if (context.WebSockets.IsWebSocketRequest)
            {
                using (WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync())
                {
                    while (!HttpContext.RequestAborted.IsCancellationRequested)
                    {
                        var response = string.Format("Hello! Time {0}", System.DateTime.Now.ToString());
                        var bytes = System.Text.Encoding.UTF8.GetBytes(response);

                        await webSocket.SendAsync(new System.ArraySegment<byte>(bytes),
                            WebSocketMessageType.Text, true, CancellationToken.None);

                        await Task.Delay(2000);
                    }
                }
            }
            else
            {
                return new StatusCodeResult(403);
            }
            return new StatusCodeResult(101);
        }

        // GET api/<SocketController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SocketController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SocketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SocketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}