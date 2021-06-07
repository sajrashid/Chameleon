namespace Chameleon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SQLiteDBContext _context;

        public LoginController(SQLiteDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet("{username}")]
        public async Task<ActionResult<bool>> GetAppUser(string email, string password)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = System.Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            //save password hash in DB

            var appUser = await _context.AppUser.FirstOrDefaultAsync(u => u.Email == email);

            if (appUser is not null)
            {
                if (appUser.Password == hashed)
                {
                    return true;
                }
            }

            return false;
        }
    }
}