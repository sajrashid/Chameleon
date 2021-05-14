using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataShared.Models;

namespace GeneralApi.DbContexts
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public DbSet<Machine> Machines { get; set; }
        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                        => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
       
   
    }
}
