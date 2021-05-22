using Chameleon.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Metadata.Internal;

namespace Chameleon.Server.DBContext
{
    public class SQLiteDBContext : DbContext
    {
        public DbSet<Machine> Machines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sqlitedemo.db");

        public DbSet<AppUser> AppUser { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<AppUser>()
                    .Property(b => b.FirstName)
                    .IsRequired()
                    .HasMaxLength(16);
                modelBuilder.Entity<AppUser>()
                   .Property(b => b.LastName)
                   .IsRequired()
                   .HasMaxLength(16);
                modelBuilder.Entity<AppUser>()
                    .Property(b => b.Username)
                    .IsRequired()
                    .HasMaxLength(16);
                 modelBuilder.Entity<AppUser>()
                    .Property(b => b.Theme)
                    .HasMaxLength(24);

                modelBuilder.Entity<Machine>()
                       .Property(m => m.Name)
                       .IsRequired()
                       .HasMaxLength(24);
                modelBuilder.Entity<Machine>()
                       .Property(m => m.Host)
                       .IsRequired()
                       .HasMaxLength(48);
                modelBuilder.Entity<Machine>()
                       .Property(m => m.Type)
                       .IsRequired()
                      
                       .HasMaxLength(16);
            
        }
        #endregion
    }
}