using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Client.Pages.Components.Main
{
    public partial class MConsole
    {
        [Inject]
        private IJSRuntime JS { get; set; }
      
        public ConsoleSelect ConsoleSelect { get; set; } = new();

        private bool ExpandedCss { get; set; } = true;
        private bool RotateCss { get; set; } = false;

        private void ExpandClick()
        {
            ExpandedCss = !ExpandedCss;
            RotateCss = !RotateCss;
        }
        private bool ExpandedPopupCss { get; set; } = false;

        private void TogglePopup()
        {
            ExpandedPopupCss = !ExpandedPopupCss;
        }
        private string FColorcss { get; set; } = "text-white";

        private async Task SelectFColorClick(ChangeEventArgs e)
        {
            FColorcss= e.Value.ToString();
            await InvokeAsync(StateHasChanged);
        }

        private string BkGrndcss { get; set; } = "bg-black";
        private async Task SelectBColorClick(ChangeEventArgs e)
        {
            BkGrndcss = e.Value.ToString();
            await InvokeAsync(StateHasChanged);
        }


        private string GcodeTextArea { get; set; } = "";
        private string GcodeInput { get; set; } = "";

        private async Task OnGcodeSendClick()
        {
            if (GcodeInput!="")
            {
                GcodeTextArea += GcodeInput + System.Environment.NewLine;
                GcodeInput = "";
                await InvokeAsync(StateHasChanged);
                await AutoScrollTextArea();
            }
        }

        string KeyPressed = "";
        private async Task KeyboardEventHandler(KeyboardEventArgs args)
        {
            
            KeyPressed =  args.Key;
            
            if (KeyPressed=="Enter" && GcodeInput != "")
            {
                GcodeTextArea += GcodeInput += System.Environment.NewLine;
                GcodeInput = "";
                await AutoScrollTextArea();
            }
          
        }

        ElementReference TextAreaRef;
        private async Task AutoScrollTextArea()
        {
            await JS.InvokeAsync<object>
           ("scrollToEnd", new object[] { TextAreaRef });
        }
    }
    public  class ConsoleSelect
    {
        public List<Colour> BColorList { get; set; } = new()
        {
            new Colour("bg-white", "White"),
            new Colour("bg-black", "Black"),
            new Colour("bg-gray-100", "Light Gray"),
            new Colour("bg-gray-900", "Dark Gray"),
            new Colour("BGreen", "Green"),
            new Colour("BYellow", "Yellow"),
            new Colour("BRed", "Red"),
            new Colour("BIndigo", "Indigo"),
        };
        public string SelectedBColor { get; set; } = "bg-black";

        public List<Colour> FColorList { get; set; } = new()
        {
            new Colour("text-white", "White"),
            new Colour("text-black", "Black"),
            new Colour("text-gray-100", "Light Gray"),
            new Colour("text-gray-900", "Dark Gray"),
            new Colour("FYellow", "Yellow"),
            new Colour("FGreen", "Green"),
            new Colour("FRed", "Red"),
            new Colour("FIndigo", "Indigo"),
        };
        public string SelectedFColor { get; set; } = "text-white";
    }
    public class Colour
    {
        public Colour(string value, string name)
        {
            Value = value;
            Name = name;
        }

        public string Value { get; set; }
        public string Name { get; set; }
    }
}
