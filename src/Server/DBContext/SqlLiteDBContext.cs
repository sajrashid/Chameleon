using Chameleon.Shared;
using Microsoft.EntityFrameworkCore;

namespace Chameleon.Server.DBContext
{
    public class SQLiteDBContext : DbContext
    {
        public DbSet<Machine> Machines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sqlitedemo.db");

        public DbSet<AppUser> AppUser { get; set; }
    }
}