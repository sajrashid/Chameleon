using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Server.Repository

{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T> GetById(object id);
    }
}