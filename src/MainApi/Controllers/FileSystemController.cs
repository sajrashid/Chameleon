﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Data.shared.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeneralApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileSystemController : ControllerBase
    {
        private IWebHostEnvironment _env;
        public FileSystemController(IWebHostEnvironment env)
        {
            _env = env;
        }
        //
        // GET: api/<FileSystemController>
        [HttpGet]
        public async Task<ActionResult>  Get()
        {
            var ListFiles = new List<UploadedFiles>();
            //https://www.mikesdotnetting.com/article/302/server-mappath-equivalent-in-asp-net-core
            var path = _env.WebRootPath;
            try
            {
                await Task.Run(() => {
                    var Counter = 0;
                    DirectoryInfo Dir = new DirectoryInfo(path);
                    FileInfo[] FileList = Dir.GetFiles("*.*", SearchOption.AllDirectories);
                    foreach (FileInfo FI in FileList)
                    {
                        var File = new UploadedFiles();
                        Console.WriteLine(FI.FullName);
                        File.Id = Counter;
                        File.Name = FI.Name;
                        File.Size = FI.Length;
                        ListFiles.Add(File);
                        File.Id = Counter;
                        Counter++;

                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok(ListFiles);
        }

        // GET api/<FileSystemController>/5
        

        // POST api/<FileSystemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FileSystemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileSystemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
