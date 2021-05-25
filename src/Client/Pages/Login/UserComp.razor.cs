using Chameleon.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chameleon.Client.Pages.Login
{
    public partial class UserComp
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Parameter] public string Title { get; set; }
        [Parameter] public string Link1Title { get; set; }
        [Parameter] public string Link1Text { get; set; }
        [Parameter] public string Link1Href { get; set; }

        [Parameter] public string Link2Title { get; set; }

        [Parameter] public string Link2Text { get; set; }
        [Parameter] public string Link2Href { get; set; }

        [Parameter] public string ApiUrl { get; set; }

        private bool isCredsValid { get; set; } = false;
        public UserCredentials UserCreds { get; set; } = new UserCredentials();
        public string TxtType = "password";

        private string ApiResponseMessage { get; set; } = "";
        private bool IsPasswordEyeOpen { get; set; } = true;

        


        public void ShowPassword()
        {
            IsPasswordEyeOpen = !IsPasswordEyeOpen;
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
            var Email = UserCreds.Email;
            if (IsValidEmail(Email)  && password.Length > 7)
            {
                isCredsValid = await Http.GetFromJsonAsync<bool>("api/login/" + UserCreds.Email + "?password=" + password);
                Console.WriteLine(UserCreds.Email + " :" + UserCreds.Password);
            }
            // generate a 128-bit salt using a secure PRNG
            //save password hash in DB
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}