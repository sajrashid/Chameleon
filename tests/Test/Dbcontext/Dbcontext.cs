using Chameleon.Shared;
using Microsoft.Data.Sqlite;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Test;


          static SQLiteDBContext GetSomeDatabaseContext() {

        var connection = new SqliteConnection("DataSource=:memory:");
        var options = new DbContextOptionsBuilder<SQLiteDBContext>()
         .UseSqlite(connection)
           .Options;
        connection.Open();

            using (var context = new SQLiteDBContext(options))
            {
                context.Database.EnsureCreated();
            }

            return new SQLiteDBContext(options);
        }




