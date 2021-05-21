using Chameleon.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

using System.Threading.Tasks;

namespace Chameleon.Client.Pages.Login
{
    public partial class GetUsers
    {
        [Inject]
        private HttpClient Http { get; set; }
        public List<AppUser> Users { get; set; } = new List<AppUser>();

        protected override async Task OnInitializedAsync()
        {
            Users = await Http.GetFromJsonAsync<List<AppUser>>("api/users");
        }
    }
}
