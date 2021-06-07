


namespace Chameleon.Server.Repository
{
    public class OrdersRepository : SqlRepository<Machine>, IOrdersRepository
    {
        private readonly SQLiteDBContext _context;
        public OrdersRepository(SQLiteDBContext _context )
             : base(_context)
        {
        }


        public override IQueryable<Machine> GetAll()
        {
            return EfDbSet;
        }

        public override async Task<Machine> GetById(object id)
        {
            return await GetAll().SingleOrDefaultAsync(o => o.Id == (int)id);
        }

        public async Task Insert(Machine machine)
        {
            await EfDbSet.AddAsync(machine);
        }

        public async Task Update(Machine machine)
        {
            var entry = Context.Entry(machine);
            if (entry.State == EntityState.Detached)
            {
                var attachedOrder = await GetById(machine.Id);
                if (attachedOrder != null)
                {
                    Context.Entry(attachedOrder).CurrentValues.SetValues(machine);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        public void Delete(Machine machine)
        {
            EfDbSet.Remove(machine);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }

    public interface IOrdersRepository
    {
        Task Insert(Machine machine);
        Task Update(Machine machine);
        void Delete(Machine machine);
        void Save();
    }
}
