namespace Chameleon.Client.Pages.Components
{
    public partial class TestTable
    {
        [Inject]
        private HttpClient Http { get; set; }

        public List<AppUser> ListUsers = new();

        private List<PropertyInfo> properties;
        private List<string> propertiesValues;
        private List<string> focusedRowProperties;

        protected void SetProps<T>(List<T> List)
        {
            properties = new();
            propertiesValues = new();
            focusedRowProperties = new();
            foreach (var prop in typeof(T).GetProperties())
            {
                properties.Add(prop);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            ListUsers = await Http.GetFromJsonAsync<List<AppUser>>("api/Users");
            SetProps<AppUser>(ListUsers);
        }

        private void HandleValidSubmit()
        {
        }
    }
}