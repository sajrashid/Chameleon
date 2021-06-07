namespace Chameleon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlbModelsController : ControllerBase
    {
        private readonly SQLiteDBContext _context;

        public GlbModelsController(SQLiteDBContext context)
        {
            _context = context;
        }

        // GET: api/GlbModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GlbModel>>> GetGlbModel()
        {
            return await _context.GlbModel.ToListAsync();
        }

        // GET: api/GlbModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GlbModel>> GetGlbModel(int id)
        {
            var glbModel = await _context.GlbModel.FindAsync(id);

            if (glbModel == null)
            {
                return NotFound();
            }

            return glbModel;
        }

        // PUT: api/GlbModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGlbModel(int id, GlbModel glbModel)
        {
            if (id != glbModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(glbModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlbModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GlbModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GlbModel>> PostGlbModel(GlbModel glbModel)
        {
            _context.GlbModel.Add(glbModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGlbModel", new { id = glbModel.Id }, glbModel);
        }

        // DELETE: api/GlbModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGlbModel(int id)
        {
            var glbModel = await _context.GlbModel.FindAsync(id);
            if (glbModel == null)
            {
                return NotFound();
            }

            _context.GlbModel.Remove(glbModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GlbModelExists(int id)
        {
            return _context.GlbModel.Any(e => e.Id == id);
        }
    }
}