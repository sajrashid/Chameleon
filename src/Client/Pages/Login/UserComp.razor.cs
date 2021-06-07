



namespace Chameleon.Client.Pages.Login
{
    public partial class UserComp
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Parameter] public UserOptions Options { get; set; }
        private bool IsCredsValid { get; set; } = false;
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
                IsCredsValid = await Http.GetFromJsonAsync<bool>("api/login/" + UserCreds.Email + "?password=" + password);
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

    public class UserOptions
    {
       public string Title { get; set; }
       public string Link1Title { get; set; }
       public string Link1Text { get; set; }
       public string Link1Href { get; set; }

       public string Link2Title { get; set; }

       public string Link2Text { get; set; }
       public string Link2Href { get; set; }

       public string ApiUrl { get; set; }

    }


}