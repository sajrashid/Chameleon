﻿using Data.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MainApi.Controllers
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
