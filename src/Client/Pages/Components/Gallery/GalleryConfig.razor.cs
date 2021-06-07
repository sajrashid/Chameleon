namespace Chameleon.Client.Pages.Components.Gallery
{
    public partial class GalleryConfig
    {
        [Inject]
        private HttpClient Http { get; set; }

        public string InputID = "input-id";
        public string Output = "";

        public class InputTextClass
        {
            public string TextValue = "Some Random Text";
        }

        public InputTextClass inputText = new();

        public async void BtnApiTestClick()
        {
            var url = inputText.TextValue;
            var HELLO = new HelloWorld();

            HELLO = await Http.GetFromJsonAsync<HelloWorld>("api/ApiTest");
            Output = HELLO.Greetings;
            await InvokeAsync(StateHasChanged);
        }
    }
}