namespace Chameleon.Client.Services
{
    using System.Threading.Tasks;

    public interface IApiService<T> where T : class
    {
        Task<T> OnGet(string url);
    }
}