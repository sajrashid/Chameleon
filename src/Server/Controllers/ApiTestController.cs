using Chameleon.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chameleon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTestController : ControllerBase
    {
        // GET: api/<ApiTestController>
        [HttpGet]
        public ActionResult<HelloWorld> Get()
        {
            var Hello = new HelloWorld();
            Hello.Greetings = "HelloWorld";
            return Hello;
        }

        //[HttpGet]
        //public ActionResult Gete()
        //{
        //    return new StatusCodeResult(200);
        //}
    }
}