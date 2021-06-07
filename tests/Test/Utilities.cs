using System.Collections.Generic;

using Chameleon.Shared;

namespace Test
{
    public static class Utilities
    {
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
                    new Machine(){ Name = "Apples" },
                    new Machine(){ Name = "Oranges" },
                    new Machine(){ Name = "Pears"  }
                };
        }
    }
}