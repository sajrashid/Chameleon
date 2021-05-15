
namespace Chameleon.Pages.Components.Gallery
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Chameleon.Services;
    using DataShared.Models;
    using Microsoft.AspNetCore.Components;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;

    public partial class GalleryConfig
    {
        [Inject]
        private IApiService<HelloWorld> ApiService { get; set; }
        [Inject]
        private IOptionsMonitor<AppSettings> Settings { get; set; }
        public string InputID = "input-id";
        public string Output = "";

        public class InputTextClass
        {
            public string TextValue = "Some Random Text";
        }

        public InputTextClass inputText = new InputTextClass();

        public async Task BtnApiTestClick()
        {
            var url = inputText.TextValue;
            Console.WriteLine(Settings.CurrentValue.ApiUrl);

            var HELLO = new HelloWorld();
            HELLO = await ApiService.OnGet("http://localhost:5001/api/apiTest");
            Output = HELLO.Greetings;
            await InvokeAsync(StateHasChanged);
        }
    }
   
}
