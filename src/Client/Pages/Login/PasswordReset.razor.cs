namespace Chameleon.Client.Pages.Login
{
    public partial class PasswordReset
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