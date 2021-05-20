using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chameleon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBConnectionsController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DBConnectionsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/<DBConnectionsController>
        [HttpGet]
        public async Task<string> Get()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            Console.WriteLine(webRootPath);
            Console.WriteLine(contentRootPath);
            string jsonString = string.Empty;
            using (var reader = System.IO.File.OpenText(@webRootPath + "\\DbConnection.json"))
            {
                jsonString = await reader.ReadToEndAsync();
                // Do something with fileText...
            }
            Console.WriteLine(jsonString);
            var s = JsonSerializer.Deserialize<AppSettings>(jsonString);

            return s.StorageOptions.Name;
        }

        // GET api/<DBConnectionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DBConnectionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DBConnectionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DBConnectionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
