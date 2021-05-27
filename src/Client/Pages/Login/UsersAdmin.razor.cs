using Chameleon.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chameleon.Client.Pages.Login
{
    public partial class UsersAdmin
    {
        [Inject]
        private HttpClient Http { get; set; }

        List<AppUser> ListModel;

        protected override async Task OnParametersSetAsync()
        {
            ListModel = await Http.GetFromJsonAsync<List<AppUser>>("api/Users");
        }

        private void UpdateUsers(AppUser users)
        {
            Console.WriteLine(users.Email);
        }
    }

  
}