using Chameleon.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

using System.Threading.Tasks;

namespace Chameleon.Client.Pages.Login
{
    public partial class CreateUser
    {
        [Inject]
        private HttpClient Http { get; set; }
        public AppUser User { get; set; } = new AppUser();

        public AppUser AppUser { get; set; }
      

        public async Task<AppUser> Register(AppUser User)
        {
            var response = await Http.PostAsJsonAsync("api/Users", User);
            return await response.Content.ReadFromJsonAsync<AppUser>();
        }
    }
}
