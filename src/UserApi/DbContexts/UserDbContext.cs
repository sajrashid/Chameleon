using BlazorSignalR.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace BUSerApi.DbContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                        => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
         //   => options.UseMySQL(@"Data Source=server=localhost;database=Chameleon;user=mysqlschema;password=redstar99");
    }
}
