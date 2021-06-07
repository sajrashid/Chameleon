namespace Chameleon.Server.Controllers
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
        public async Task<ActionResult> Get()
        {
            var ListFiles = new List<UploadedFiles>();
            var path = _env.WebRootPath;
            try
            {
                await Task.Run(() =>
                {
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