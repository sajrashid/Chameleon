using GcodeApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GcodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {

        private readonly RestService _restService;

        public RestController(RestService restService)
        {
            _restService = restService;
        }

      


        // GET: api/<httpController>
        [HttpGet]
        public async  Task<HttpResponseMessage> Get()
        {
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
