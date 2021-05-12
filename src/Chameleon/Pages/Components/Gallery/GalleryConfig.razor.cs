namespace Chameleon.Pages.Components.Gallery
{
    using System.Threading.Tasks;
    using Chameleon.Services;
    using Microsoft.AspNetCore.Components;
    using Data.Shared.Models;

    public partial class GalleryConfig
    {
        [Inject]
        private IApiService<HelloWorld> ApiService {get; set;}


        public string InputID = "input-id";
        public string Output = "";

        public class InputTextClass
        {
            public string TextValue = "Some Random Text";
        }

        public InputTextClass inputText = new InputTextClass();

        public async Task BtnApiTestClick()
        {
            var HELLO = new HelloWorld();
            HELLO = await ApiService.OnGet("http://localhost:5001/api/apiTest");
            Output = HELLO.Greetings;
            await InvokeAsync(StateHasChanged);
        }
    }
    
}


