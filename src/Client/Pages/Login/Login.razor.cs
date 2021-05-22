using Chameleon.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
        InputText userNameReference;
        public Chameleon.Shared.Login UserCreds { get; set; } = new Chameleon.Shared.Login();
        public string TxtType = "password";

        protected override async Task OnAfterRenderAsync(bool first)
         {
            if (first)
            {
                await userNameReference.Element.Value.FocusAsync();
            }
         }
        public void ShowPassword()
        {

            if (this.TxtType == "password")
            {
                this.TxtType = "text";
            }
            else
            {
                this.TxtType = "password";
            }
        }
        public async void HandleValidSubmit()
        {
            var password = UserCreds.Password;
            var userName = UserCreds.Username;
            if (userName.Length > 5 && password.Length > 7 )
            {
                isCredsValid = await Http.GetFromJsonAsync<bool>("api/login/" + UserCreds.Username + "?password=" + password);
            }
            // generate a 128-bit salt using a secure PRNG
            //save password hash in DB
        }
    }
}
