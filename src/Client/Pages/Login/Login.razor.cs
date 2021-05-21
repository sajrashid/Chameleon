﻿using Chameleon.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chameleon.Client.Pages.Login
{
    public partial class Login
    {
        [Inject]
        private HttpClient Http { get; set; }
        private bool isCredsValid { get; set; } = false;

        public Chameleon.Shared.Login UserCreds { get; set; } = new Chameleon.Shared.Login();

        protected override async Task OnInitializedAsync()
        {
            var isCredsValid = await Http.GetFromJsonAsync<bool>("api/login/"+UserCreds.Username + "?passwordhash="+UserCreds.Password);
        }

        public async void HandleValidSubmit()
        {
            var password = UserCreds.Password;
            // generate a 128-bit salt using a secure PRNG
            //save password hash in DB
            isCredsValid = await Http.GetFromJsonAsync<bool>("api/login/" + UserCreds.Username + "?password="+password);
        }
    }
}
