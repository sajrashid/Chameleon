using System.Collections.Generic;
using Chameleon.Server.DBContext;
using Chameleon.Shared;

namespace RazorPagesProject.Tests
{
    public static class Utilities
    {
        #region snippet1
        public static void InitializeDbForTests(SQLiteDBContext db)
        {
            db.Machines.AddRange(GetSeedingMessages());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(SQLiteDBContext db)
        {
            db.Machines.RemoveRange(db.Machines);
            InitializeDbForTests(db);
        }

        public static List<Machine> GetSeedingMessages()
        {
            return new List<Machine>()
            {
                new Machine(){ Name = "TEST RECORD: You're standing on my scarf." },
                new Machine(){ Name = "TEST RECORD: Would you like a jelly baby?" },
                new Machine(){ Name = "TEST RECORD: To the rational mind, " +
                    "nothing is inexplicable; only unexplained." }
            };
        }
        #endregion
    }
}