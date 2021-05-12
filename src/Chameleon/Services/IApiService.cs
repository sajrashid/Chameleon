namespace Chameleon.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IApiService<T> where T : class
    {
        Task<T> OnGet(string url);
    }
}
