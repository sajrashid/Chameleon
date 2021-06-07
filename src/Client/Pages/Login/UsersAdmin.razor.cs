namespace Chameleon.Client.Pages.Login
{
    public partial class UsersAdmin
    {
        [Inject]
        private HttpClient Http { get; set; }

        private List<AppUser> ListModel;

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